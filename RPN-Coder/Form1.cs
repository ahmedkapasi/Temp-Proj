using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPN_Coder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable cols_dt;
        DataTable actions_dt = new DataTable();
        string searchString = Properties.Resources.rpnSearchString;
        string baseFolderPath = ConfigurationManager.AppSettings["baseFolderPath"].ToString();
        string gridActionTemplate = Properties.Resources.gridActionTemplate;
        string parentModule = ConfigurationManager.AppSettings["parentModule"].ToString();
        string appFolderPath = ConfigurationManager.AppSettings["appFolderPath"].ToString();
        Dictionary<string, string> injectors = new Dictionary<string, string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_com_module.Text = parentModule;
            txt_appFolderPath.Text = appFolderPath;
        }
        private void btn_gen_flds_Click(object sender, EventArgs e)
        {
            cols_dt = new DataTable();
            cols_dt.Columns.Add("Column");
            cols_dt.Columns.Add("Header Text");

            string strCols = txt_cols.Text;
            string[] Cols = strCols.Split(',');
            foreach (string s in Cols)
            {
                if (s != string.Empty)
                {
                    string hdrTxt = Regex.Replace(s, "(\\B[A-Z])", " $1");
                    cols_dt.Rows.Add(cols_dt.NewRow());
                    cols_dt.Rows[cols_dt.Rows.Count - 1]["Column"] = s;
                    cols_dt.Rows[cols_dt.Rows.Count - 1]["Header Text"] = hdrTxt.Substring(0, 1).ToUpper() + hdrTxt.Substring(1, hdrTxt.Length - 1);

                }
            }
            if (cols_dt.Rows.Count > 0)
            {
                grd_col_dtls.DataSource = cols_dt;
            }
        }

        private void btn_add_actions_Click(object sender, EventArgs e)
        {
            if (actions_dt.Columns.Count <= 0)
            {
                actions_dt.Columns.Add("Action");
            }
            actions_dt.Rows.Add(actions_dt.NewRow());
            grd_actions.DataSource = actions_dt;
        }

        private void btn_clr_actions_Click(object sender, EventArgs e)
        {
            actions_dt.Rows.Clear();
            grd_actions.DataSource = null;
        }

        private void chk_grd_actions_CheckedChanged(object sender, EventArgs e)
        {
            pnl_grd_actions.Enabled = chk_grd_actions.Checked;
        }

        private void btn_gen_code_Click(object sender, EventArgs e)
        {
            string com_module = txt_com_module.Text;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (baseFolderPath != string.Empty)
            {
                fbd.SelectedPath = baseFolderPath;
            }
            DialogResult fdr = fbd.ShowDialog();
            if (fdr.ToString().ToLower() == "cancel")
            {
                return;
            }
            string targetPath = fbd.SelectedPath;
            generatCode(targetPath);

        }

        private void generatCode(string selectedPath)
        {
            string modulename = txt_Module_Name.Text;
            if (modulename == string.Empty)
            {
                return;
            }
            modulename = Regex.Replace(modulename, "(\\B[A-Z])", "-$1").ToLower();

            string targetpath = selectedPath + "\\" + modulename;
            Directory.CreateDirectory(targetpath);
            string[] files = Directory.GetFiles("Templates");


            foreach (string dirPath in Directory.GetDirectories("Templates", "*",
            SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace("Templates", targetpath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles("Templates", "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace("Templates", targetpath), true);

            removeRanameFiles(targetpath);
            if (injectors.Count == 0)
            {
                createInjectors();
            }
            updateFilesWithInjectors(targetpath);
            updateGridConfigFile(targetpath);
            updateLanguageBundle(targetpath);
            addMockData(targetpath);
            DialogResult dlgRslt = MessageBox.Show("Do you want me to create your Route Settings?","Route Setting?", MessageBoxButtons.YesNo);
            if (dlgRslt.ToString().ToUpper() == "YES") {
                addRouteSettings(targetpath);
            }
            
            if (chk_grd_actions.Checked)
            {
                addGridActions(targetpath);
            }
            MessageBox.Show("Code Generated");
        }

        private void addGridActions(string targetpath)
        {
            DataTable dt = grd_actions.DataSource as DataTable;
            StringBuilder sb = new StringBuilder();
            StringBuilder actions = new StringBuilder();
            StringBuilder action_methods = new StringBuilder();

            string actionFile = Directory.GetFiles(targetpath + "//js", "*-actions.js", SearchOption.AllDirectories).FirstOrDefault();
            string contrlFile = Directory.GetFiles(targetpath + "//js/controllers", "*-ctrl.js", SearchOption.AllDirectories).FirstOrDefault();
            if (actionFile != null && contrlFile != null)
            {

                int idx = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    string actionName = "grid_action_" + idx.ToString();
                    string actionMethod = "grid_action_" + idx.ToString() + "_click";
                    string gridActTemp = Properties.Resources.gridActionTemplate;
                    string gridMtdTemp = Properties.Resources.gridActionMethodTemplate;
                    gridActTemp = gridActTemp.Replace("@@action_name@@", actionName);
                    gridActTemp = gridActTemp.Replace("@@action_method@@", actionMethod);
                    gridMtdTemp = gridMtdTemp.Replace("@@action_method@@", actionMethod);
                    actions.Append(gridActTemp + "\n");
                    action_methods.Append(gridMtdTemp + "\n");
                    idx++;
                }
                sb.Append(File.ReadAllText(actionFile));
                sb.Replace("@@action_details@@", actions.ToString());
                File.WriteAllText(actionFile, sb.ToString());
                sb.Clear();
                sb.Append(File.ReadAllText(contrlFile));
                sb.Replace("@@action_methods@@", action_methods.ToString());
                File.WriteAllText(contrlFile, sb.ToString());
            }
        }

        private void addRouteSettings(string targetpath)
        {
            string routeName = txt_Module_Name.Text;
            string routeFile = Directory.GetFiles(appFolderPath + "//js//config", "routes.js", SearchOption.AllDirectories).FirstOrDefault();
            string lazyloadfile = Directory.GetFiles(appFolderPath + "//js//config", "lazyload.js", SearchOption.AllDirectories).FirstOrDefault();
            string moduleName = Regex.Replace(txt_Module_Name.Text, "(\\B[A-Z])", "-$1").ToLower().ToLower();
            if (routeFile != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(File.ReadAllText(routeFile));
                string fileBundle = txt_com_module.Text + "." + moduleName;
                string routeTemp = Properties.Resources.routeTemplate;
                string srchString = Properties.Resources.rpnSearchString;
                routeTemp = routeTemp.Replace("@@module_name@@", moduleName);
                routeTemp = routeTemp.Replace("@@module_url@@", moduleName.Replace("-", ""));
                routeTemp = routeTemp.Replace("@@controller_name@@", injectors["@@controller_name@@"]);
                routeTemp = routeTemp.Replace("@@module_file_bundle@@", fileBundle);
                routeTemp = routeTemp + "\n\n" + srchString; //add search string again for future use
                sb.Replace(srchString, routeTemp);
                File.WriteAllText(routeFile, sb.ToString());
                if (lazyloadfile != null)
                {
                    sb = new StringBuilder();
                    sb.Append(File.ReadAllText(lazyloadfile));
                    string lazyloadTemp = Properties.Resources.lazyloadTemplate;
                    lazyloadTemp = lazyloadTemp.Replace("@@module_name@@", moduleName);
                    lazyloadTemp = lazyloadTemp + "\n\n" + srchString; //add search string again for future use
                    sb.Replace(srchString, lazyloadTemp);
                    File.WriteAllText(lazyloadfile, sb.ToString());
                }
            }

        }

        private void addMockData(string targetpath)
        {
            DataTable dt = grd_col_dtls.DataSource as DataTable;
            StringBuilder sb = new StringBuilder();
            StringBuilder mockdata = new StringBuilder();
            string modelFile = Directory.GetFiles(targetpath + "//js", "*-model.js", SearchOption.AllDirectories).FirstOrDefault();
            if (modelFile != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    mockdata.AppendFormat("'{0}':'{1}',", dr["Column"].ToString(), dr["Header Text"].ToString());
                }
                sb.Append(File.ReadAllText(modelFile));
                sb.Replace("@@grid_mock_data@@", "{" + mockdata.ToString() + "}");
                File.WriteAllText(modelFile, sb.ToString());
            }

        }

        private void updateLanguageBundle(string targetpath)
        {
            string keyFile = Directory.GetFiles(targetpath + "//js-lang", "keys.js", SearchOption.AllDirectories).FirstOrDefault();
            string resourceFile = Directory.GetFiles(targetpath + "//js-lang", "resource.js", SearchOption.AllDirectories).FirstOrDefault();
            if (keyFile != null && resourceFile != null)
            {
                Dictionary<string, string> lang = new Dictionary<string, string>();
                DataTable dt = grd_col_dtls.DataSource as DataTable;
                foreach (DataRow dr in dt.Rows)
                {
                    lang.Add("grid_hdr_" + dr["Column"].ToString(), dr["Header Text"].ToString());
                }
                if (chk_grd_actions.Checked)
                {
                    dt = grd_actions.DataSource as DataTable;
                    int idx = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        string action = "grid_action_" + idx.ToString();
                        lang.Add(action, dr["Action"].ToString());
                        idx++;
                    }
                }
                StringBuilder sb_resources = new StringBuilder();
                StringBuilder sb_keys = new StringBuilder();
                foreach (string key in lang.Keys)
                {
                    sb_resources.AppendFormat("'{0}':'{1}',\n", key, lang[key]);
                    sb_keys.AppendFormat("'{0}',\n", key);
                }
                StringBuilder file_data = new StringBuilder();
                file_data.Append(File.ReadAllText(keyFile));
                file_data.Replace("@@lang_keys@@", sb_keys.ToString());
                File.WriteAllText(keyFile, file_data.ToString());
                file_data = new StringBuilder();
                file_data.Append(File.ReadAllText(resourceFile));
                file_data.Replace("@@lang_resources@@", sb_resources.ToString());
                File.WriteAllText(resourceFile, file_data.ToString());
            }
        }

        private void updateGridConfigFile(string targetpath)
        {
            string[] files = Directory.GetFiles(targetpath, "*grid-config.js", SearchOption.AllDirectories);
            if (files.Length <= 0) { return; }

            StringBuilder sb = new StringBuilder();
            sb.Append(File.ReadAllText(files[0]));

            DataTable dt = grd_col_dtls.DataSource as DataTable;
            StringBuilder colHdr = new StringBuilder();
            StringBuilder colDtl = new StringBuilder();
            StringBuilder colFlt = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                string colDtlTemp = Properties.Resources.gridColsDetailsTemplate;
                string colHdrTemp = Properties.Resources.gridColsHdrTemplate;
                string colFltrTemp = Properties.Resources.gridColsFltrTemplate;
                colDtlTemp = colDtlTemp.Replace("@@col_name@@", dr["Column"].ToString());

                colHdrTemp = colHdrTemp.Replace("@@col_name@@", dr["Column"].ToString());
                colHdrTemp = colHdrTemp.Replace("@@col_text@@", "grid_hdr_" + dr["Column"].ToString());

                colFltrTemp = colFltrTemp.Replace("@@col_name@@", dr["Column"].ToString());
                colFltrTemp = colFltrTemp.Replace("@@col_type@@", "text");

                colDtl.Append(colDtlTemp + "\n");
                colHdr.Append(colHdrTemp + "\n");
                colFlt.Append(colFltrTemp + "\n");
            }
            sb.Replace("@@column_details@@", colDtl.ToString());
            sb.Replace("@@column_headers@@", colHdr.ToString());
            sb.Replace("@@column_filters@@", colFlt.ToString());
            File.WriteAllText(files[0], sb.ToString());
        }

        private void createInjectors()
        {

            string comParentModule = txt_com_module.Text;
            string moduleName = txt_Module_Name.Text;
            string controllerName = moduleName.Substring(0, 1).ToUpper() + moduleName.Substring(1, moduleName.Length-1);
            injectors.Add("@@common_module@@", comParentModule);
            injectors.Add("@@module_name@@", moduleName);
            injectors.Add("@@controller_name@@", controllerName + "Controller");
            injectors.Add("@@model_name@@", moduleName + "Model");
            injectors.Add("@@grid_action_model@@", moduleName + "GridActionModel");
            injectors.Add("@@grid_config_model@@", moduleName + "GridConfigModel");
            injectors.Add("@@service_model@@", moduleName + "Svc");
            injectors.Add("@@lang_module_name@@", moduleName + "LangBundle");
        }

        private void updateFilesWithInjectors(string targetpath)
        {
            string modulename = txt_Module_Name.Text;
            string modulename2 = Regex.Replace(modulename, "(\\B[A-Z])", "-$1").ToLower();
            string[] files = Directory.GetFiles(targetpath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(File.ReadAllText(file));
                if (file.Contains("scripts.inc")) //exclude scripts.inc files
                {
                    sb.Replace("@@module_name@@", modulename2);
                }
                else
                {
                    foreach (string key in injectors.Keys)
                    {
                        sb.Replace(key, injectors[key]);
                    }
                }

                File.WriteAllText(file, sb.ToString());
            }
        }

        private void removeRanameFiles(string targetpath)
        {
            string modulename = txt_Module_Name.Text;
            modulename = Regex.Replace(modulename, "(\\B[A-Z])", "-$1");

            string controllerPath = targetpath + "\\js\\controllers";
            string modelsPath = targetpath + "\\js\\models";
            string servicePath = targetpath + "\\js\\services";
            string jsPath = targetpath + "\\js";
            if (chk_grd_actions.Checked) //if grid has action menus
            {
                File.Delete(controllerPath + "\\controller.js");
                File.Delete(modelsPath + "\\grid-config.js");
                File.Delete(jsPath + "\\scripts.inc");

                File.Move(controllerPath + "\\controller-with-actions.js",
                    controllerPath + "\\" + modulename.ToLower() + "-ctrl.js");
                File.Move(modelsPath + "\\grid-config-with-actions.js",
                    modelsPath + "\\" + modulename.ToLower() + "-grid-config.js");
                File.Move(modelsPath + "\\grid-actions.js",
                    modelsPath + "\\" + modulename.ToLower() + "-grid-actions.js");

                File.Move(jsPath + "\\scripts-with-actions.inc",
                    jsPath + "\\scripts.inc");
            }
            else
            {
                File.Delete(controllerPath + "\\controller-with-actions.js");
                File.Delete(modelsPath + "\\grid-config-with-actions.js");
                File.Delete(modelsPath + "\\grid-actions.js");
                File.Delete(jsPath + "\\scripts-with-actions.inc");

                File.Move(controllerPath + "\\controller.js",
                    controllerPath + "\\" + modulename.ToLower() + "-ctrl.js");
                File.Move(modelsPath + "\\grid-config.js",
                    modelsPath + "\\" + modulename.ToLower() + "-grid-config.js");
            }

            File.Move(modelsPath + "\\model.js",
                    modelsPath + "\\" + modulename.ToLower() + "-model.js");
            File.Move(servicePath + "\\service.js",
                    servicePath + "\\" + modulename.ToLower() + "-svc.js");


        }




    }
}
