/*
 * 
 * Author: Andrea Viotto
 * Storage Management
 * Software per gestione della SAN
 * 
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Renci.SshNet;

namespace prjSANnet
{
    public partial class PrjSAN : Form
    {

        private string username;
        private string password;
        private string ipUsed;
        private string ambiente;

        public PrjSAN()
        {
            InitializeComponent();
        }     

        private void PrjSAN_Load(object sender, EventArgs e)
        {
            loginSAN loginSAN = new loginSAN();    
            loginSAN.ShowDialog();
            this.username = loginSAN.user;
            this.password = loginSAN.passwd;
            this.ambiente = loginSAN.ambiente;
            labelInfo_acc.Text = "Logged as: " + loginSAN.user + " on " + loginSAN.ambiente;

            SANcombo.Items.Add("SAN A");
            SANcombo.Items.Add("SAN B");
            SANcombo.Text = "SAN A";

            swVersion.Items.Add("7.4.2c");
            swVersion.Items.Add("< 7.4.2c");
            swVersion.Text = "7.4.2c";

            dataGridView1.ColumnCount = 2;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].Width = 650;
            dataGridView1.Columns[1].Width = 0;
        }

        private void zoneShow_Click(object sender, EventArgs e)
        {
            string cmdRun;
            string strCmdText;
            string cmdStringOut;
            string standard_output;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns[0].Name = "Zone";
            dataGridView1.Columns[1].Width = 0;
            cmdRun = "zoneshow | grep " + hostName.Text + " | grep zone:";
            strCmdText = "-ssh " + username + "@" + ipUsed + " -pw " + password + " \"" + cmdRun + "\"";
            cmdStringOut = "plink.exe -ssh " + username + "@" + ipUsed + " -pw * \"" + cmdRun + "\"";
            logBox.Items.Add(cmdStringOut);                       

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "plink.exe";
            startInfo.Arguments = strCmdText;
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
            //outputBox.Text = process.StandardOutput.ReadToEnd().Replace("zone:", "");

            while (!process.StandardOutput.EndOfStream)
            {
                standard_output = process.StandardOutput.ReadLine().Replace("zone:", "");
                dataGridView1.Rows.Add(standard_output);
            }
        }

        private void SANcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SANcombo.Text == "SAN A")
            {
                if (ambiente == "SAN PSM")
                {
                    ipUsed = "172.31.41.26";
                }
                else if (ambiente == "SAN IOL SZ")
                {
                    ipUsed = "10.174.224.75";
                }
                else if (ambiente == "SAN TO")
                {
                    ipUsed = "172.30.32.18";
                }
                else
                {
                    ipUsed = "10.174.10.102";
                }

            } else
            {
                if (ambiente == "SAN PSM")
                {
                    ipUsed = "172.31.41.29";
                }
                else if (ambiente == "SAN IOL SZ")
                {
                    ipUsed = "10.174.224.140";
                }
                else if (ambiente == "SAN TO")
                {
                    ipUsed = "172.30.32.19";
                }
                else
                {
                    ipUsed = "10.174.10.103";
                }
            }
        }

        private void aliShow_Click(object sender, EventArgs e)
        {
            string cmdRun;
            string strCmdText;
            string cmdStringOut;
            string standard_output;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns[0].Name = "Alias";
            dataGridView1.Columns[1].Width = 0;
            cmdRun = "alishow | grep " + hostName.Text + " | grep alias:";
            strCmdText = "-ssh " + username + "@" + ipUsed + " -pw " + password + " \"" + cmdRun + "\"";
            cmdStringOut = "plink.exe -ssh " + username + "@" + ipUsed + " -pw * \"" + cmdRun + "\"";
            logBox.Items.Add(cmdStringOut);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "plink.exe";
            startInfo.Arguments = strCmdText;
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
            //outputBox.Text = process.StandardOutput.ReadToEnd().Replace("zone:", "");

            while (!process.StandardOutput.EndOfStream)
            {
                standard_output = process.StandardOutput.ReadLine().Replace("alias:", "");
                dataGridView1.Rows.Add(standard_output);
            }
        }

        private void customCMD_Click(object sender, EventArgs e)
        {
            customCMDform customCMD = new customCMDform();
            customCMD.username = this.username;
            customCMD.password = this.password;
            customCMD.ipUsed = this.ipUsed;
            customCMD.ShowDialog();
        }

        private void deleteZone_Click(object sender, EventArgs e)
        {
            string cmdRun;
            string strCmdText;
            DialogResult yesno;
            string selectionZone;
            int varChoice;

            /*
            #cfgremove "c_prod","Servername_hba1_Arrayname_SPA0"
            #cfgremove "c_prod","Servername_hba1_Arrayname_SPB1"
            #zonedelete "Servername_hba1_Arrayname_SPA0"
            #zonedelete "Servername_hba1_Arrayname_SPB1"
            */

            selectionZone = dataGridView1.CurrentCell.Value.ToString().Replace(" ", "");

            deleteZoneCustom deleteZoneCustom = new deleteZoneCustom();
            deleteZoneCustom.ShowDialog();
            varChoice = deleteZoneCustom.varReturn;

            if (varChoice != 0)
            {
                if(varChoice == 1 || varChoice == 3)
                { 
                    yesno = MessageBox.Show("Proseguire con la rimozione della zona " + selectionZone + " dalla configurazione " + configName.Text + "?", "Remove Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (yesno == DialogResult.Yes)
                    {
                        //Remove dalla configurazione
                        cmdRun = "cfgremove \"" + configName.Text + "\",\"" + selectionZone + "\"";
                        strCmdText = "plink.exe -ssh " + username + "@" + ipUsed + " -pw " + password + " \"" + cmdRun + "\"";
                        System.Diagnostics.Process processCfg = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfoCfg = new System.Diagnostics.ProcessStartInfo();
                        startInfoCfg.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfoCfg.FileName = "plink.exe";
                        startInfoCfg.Arguments = strCmdText;
                        processCfg.StartInfo = startInfoCfg;
                        processCfg.StartInfo.UseShellExecute = false;
                        processCfg.Start();
                    }
                }

                if (varChoice == 2 || varChoice == 3)
                {
                    yesno = MessageBox.Show("Proseguire con la delete della zona " + selectionZone + " dalla configurazione " + configName.Text + "?", "Remove Zone", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (yesno == DialogResult.Yes)
                    {
                        //Delete della zona
                        cmdRun = "zonedelete \"" + selectionZone + "\"";
                        strCmdText = "plink.exe -ssh " + username + "@" + ipUsed + " -pw " + password + " \"" + cmdRun + "\"";

                        System.Diagnostics.Process processZone = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfoZone = new System.Diagnostics.ProcessStartInfo();
                        startInfoZone.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfoZone.FileName = "plink.exe";
                        startInfoZone.Arguments = strCmdText;
                        processZone.StartInfo = startInfoZone;
                        processZone.StartInfo.UseShellExecute = false;
                        processZone.Start();
                    }
                }                
            }
        }

        private void findWWN_Click(object sender, EventArgs e)
        {
            string cmdRun;
            string strCmdText;
            string cmdStringOut;
            string standard_output;
            string searchWWN;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns[0].Width = 325;
            dataGridView1.Columns[0].Name = "Alias";
            dataGridView1.Columns[1].Width = 325;
            dataGridView1.Columns[1].Name = "Depend Zone";
            searchWWN = Interaction.InputBox("Insert WWN", "Insert WWN");
            if(searchWWN != "")
            {
                cmdRun = "nscamshow | grep " + searchWWN + " -5";
                strCmdText = "-ssh " + username + "@" + ipUsed + " -pw " + password + " \"" + cmdRun + "\"";
                cmdStringOut = "plink.exe -ssh " + username + "@" + ipUsed + " -pw * \"" + cmdRun + "\"";
                logBox.Items.Add(cmdStringOut);

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "plink.exe";
                startInfo.Arguments = strCmdText;
                process.StartInfo = startInfo;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();
                //outputBox.Text = process.StandardOutput.ReadToEnd().Replace("zone:", "");

                while (!process.StandardOutput.EndOfStream)
                {
                    standard_output = process.StandardOutput.ReadLine();
                    dataGridView1.Rows.Add(standard_output);
                }
            }            
        }

        private void cmdNewZoneFile_Click(object sender, EventArgs e)
        {            
            string fileName;
            string hostName;
            string storageName;
            string line;
            string[] fabricShow;
            string[,] hostWWN = new string[5, 5];
            string[,] storageWWN = new string[5, 5];
            int i;
            int fabricCount;
            string[] ipUsageSw = new string[50];
            string swHostID;
            string swStorageID;
            string zoningType;
            string swSANiD;
            string swSANiP;
            string swPort;
            string hostWWN1;
            string hostWWN2;
            string storageSVM;
            string[] aliasHostName = new string[10];
            string[] aliasStorageName = new string[10];
            string fabricType;
            string aliHostName;
            string[] arrSplitSVM = new string[5];
            string[] arrSplitStorage = new string[5];
            string[] arrStorage = new string[5];
            string storageNameNew;
            DialogResult yesno;
            int lineNumber;
            string oldswSANiP;
            string logStr;
            string cfgUsed;

            oldswSANiP = "";
            cfgUsed = "";
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            //progressBar1.MaximumSize
            logBox.Items.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns[0].Width = 650;
            dataGridView1.Columns[0].Name = "Riga letta";

            fabricShow = null;
            swHostID = "";
            swStorageID = "";
            fabricCount = 0;
            fileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                fileName = openFileDialog1.FileName;
                lineNumber = System.IO.File.ReadAllLines(@fileName).Count();
                progressBar1.Maximum = lineNumber;                
            } 
            else
            {
                return;
            }

            if (fileName != "")
            {
                yesno = MessageBox.Show("Run file " + fileName + " ?", "Run", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yesno == DialogResult.Yes)
                {
                    //ok
                    //dataGridView1.Rows.Add("In esecuzione...");
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            using (var reader = new StreamReader(@fileName))
            {                               
                while (!reader.EndOfStream)
                {                    
                    line = reader.ReadLine();
                    var arrZone = line.Split(',');
                    hostName = arrZone[0];
                    fabricType = arrZone[1];
                    zoningType = arrZone[2];
                    swSANiD = arrZone[4];
                    swSANiP = arrZone[5];
                    swPort = arrZone[6];
                    hostWWN1 = arrZone[7];
                    hostWWN2 = arrZone[8];
                    storageName = arrZone[9];
                    storageSVM = arrZone[10];
                    dataGridView1.Rows.Add(line);

                    logStr = "File aperto, inizio a leggere...";

                    //Per migliori performance - Check del cfg solo se IP diverso
                    if (swSANiP != oldswSANiP && zoningType != "Type")
                    {
                        //Estraggo gli switch della fabric                    
                        //fabricShow = getFabric(ref fabricCount);
                        logStr = "File aperto, Estraggo la config della fabric ...";
                        cfgUsed = getCfgName(fabricType, swSANiP);
                        if (configName.Text == "")
                        {
                            //retry
                            cfgUsed = getCfgName(fabricType, swSANiP);
                        }
                        configName.Text = cfgUsed;
                    }                    

                    //dataGridView1.Rows.Add(line);
                    if (zoningType == "ALIAS")
                    {
                        //ZONING CON ALIAS GIà CREATI
                        try
                        {
                            logStr = "File aperto, ALIAS ...";
                            //Estraggo gli swtich della fabric                    
                            //fabricShow = getFabric(ref fabricCount);
                            //configName.Text = getCfgName(fabricType, swSANiP);

                            if (configName.Text != "")
                            {
                                arrSplitSVM = storageSVM.Split('_');
                                swStorageID = arrSplitSVM[0].Substring(1);
                                storageSVM = arrSplitSVM[1] + "_" + arrSplitSVM[2] + "_" + arrSplitSVM[3];
                                //Cerco l'alias
                                aliasHostName = searchAliasInFabric(hostName, swSANiP);
                                //aliasStorageName = searchAliasInFabric(fabricType + "" + swSANiD + "_" + storageSVM, swSANiP);
                                aliasStorageName = searchAliasInFabric(fabricType + "" + swStorageID + "_" + storageSVM, swSANiP);

                                //Una volta estratti gli alias creo le zone                            
                                zoneCreateByAlias(aliasHostName, aliasStorageName, swSANiP, hostName, storageSVM, storageName, fabricType + "" + swSANiD);
                            }                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + " - Errore in cmdNewZoneFile_Click()" + "\n" + logStr, "Errore");
                            return;
                            //continue;
                        }
                    } 
                    else if(zoningType == "DIRECTWWN")
                    {
                        try
                        {
                            logStr = "File aperto, DIRECTWWN ...";
                            //Estraggo gli swtich della fabric                    
                            fabricShow = getFabric(ref fabricCount);
                            //configName.Text = getCfgName(fabricType, swSANiP);

                            if (configName.Text != "")
                            {
                                //Cerco HOST nella Fabric
                                for (i = 0; i < fabricCount; i++)
                                {
                                    ipUsageSw = fabricShow[i].Split(';');
                                    //Cerco la porta e il WWN dal nome HOST
                                    hostWWN = searchPortInFabric(ipUsageSw[1], hostName);
                                    if (hostWWN[1, 1] != null)
                                    {
                                        //dataGridView1.Rows.Add(hostWWN);
                                        swHostID = ipUsageSw[0];
                                        break;
                                    }
                                }
                                aliasStorageName = searchAliasInFabric(fabricType + "" + swSANiD + "_" + storageSVM, swSANiP);
                                //hostWWN - storageWWN
                                aliHostName = "";
                                aliCreate(hostWWN, storageWWN, swHostID, swStorageID, fabricType, ref aliHostName, swSANiP);
                                aliasHostName[0] = aliHostName;
                                dataGridView1.Rows.Add("Created: " + aliasHostName[0]);
                                if (swSANiD != swHostID)
                                {
                                    swSANiD = swHostID;
                                }
                                zoneCreateByAlias(aliasHostName, aliasStorageName, swSANiP, hostName, storageSVM, storageName, fabricType + "" + swSANiD);
                            }                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + " - Errore in cmdNewZoneFile_Click()" + "\n" + logStr, "Errore");
                            return;
                            //continue;
                        }
                    }
                    else if(zoningType == "MANUAL")
                    {
                        try
                        {
                            logStr = "File aperto, MANUAL ...";
                            //Estraggo gli swtich della fabric                    
                            //fabricShow = getFabric(ref fabricCount);
                            //configName.Text = getCfgName(fabricType, swSANiP);

                            if (configName.Text != "")
                            {
                                //WWN HOST
                                hostWWN[1, 0] = hostWWN1;
                                hostWWN[1, 1] = hostName;
                                swHostID = swSANiD;

                                arrSplitSVM = storageSVM.Split('_');
                                swStorageID = arrSplitSVM[0].Substring(1);
                                storageSVM = arrSplitSVM[1] + "_" + arrSplitSVM[2] + "_" + arrSplitSVM[3];
                                //Estraggo l'alias dello storage
                                aliasStorageName = searchAliasInFabric(fabricType + "" + swStorageID + "_" + storageSVM, swSANiP);
                                //Creo Alias
                                aliHostName = "";
                                aliCreate(hostWWN, storageWWN, swHostID, swStorageID, fabricType, ref aliHostName, swSANiP);
                                aliasHostName[0] = aliHostName;
                                dataGridView1.Rows.Add("Created: " + aliasHostName[0]);
                                //Creo Zoning
                                zoneCreateByAlias(aliasHostName, aliasStorageName, swSANiP, hostName, storageSVM, storageName, fabricType + "" + swSANiD);
                            }                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + " - Errore in cmdNewZoneFile_Click()" + "\n" + logStr, "Errore");
                            return;
                            //continue;
                        }
                    }
                    else if (zoningType == "MANUAL_LPAR")
                    {
                        try
                        {
                            logStr = "File aperto, MANUAL_LPAR ...";
                            //Estraggo gli swtich della fabric                    
                            //fabricShow = getFabric(ref fabricCount);
                            //configName.Text = getCfgName(fabricType, swSANiP);

                            if (configName.Text != "")
                            {
                                //WWN HOST
                                hostWWN[1, 0] = hostWWN1;
                                hostWWN[1, 2] = hostWWN2;
                                hostWWN[1, 1] = hostName;
                                swHostID = swSANiD;

                                arrSplitSVM = storageSVM.Split('_');
                                swStorageID = arrSplitSVM[0].Substring(1);
                                storageSVM = arrSplitSVM[1] + "_" + arrSplitSVM[2] + "_" + arrSplitSVM[3];
                                //Estraggo l'alias dello storage
                                aliasStorageName = searchAliasInFabric(fabricType + "" + swStorageID + "_" + storageSVM, swSANiP);
                                //Creo Alias
                                aliHostName = "";
                                aliasHostName = searchAliasInFabric(hostName, swSANiP);
                                if (aliasHostName[0] == null)
                                {
                                    //aliCreate(hostWWN, storageWWN, swHostID, swStorageID, fabricType, ref aliHostName, swSANiP);
                                    aliCreateMoreWWN(hostWWN, storageWWN, swHostID, swStorageID, fabricType, ref aliHostName, swSANiP);
                                    aliasHostName[0] = aliHostName;
                                    dataGridView1.Rows.Add("Created: " + aliasHostName[0]);
                                    //Creo Zoning
                                    zoneCreateByAlias(aliasHostName, aliasStorageName, swSANiP, hostName, storageSVM, storageName, fabricType + "" + swSANiD);
                                }
                                else
                                {
                                    aliHostName = aliasHostName[0];
                                    aliasStorageName[1] = null;
                                    //Creo Zoning
                                    zoneCreateByAlias(aliasHostName, aliasStorageName, swSANiP, hostName, storageSVM, storageName, fabricType + "" + swSANiD);
                                }
                            }                                                  
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + " - Errore in cmdNewZoneFile_Click()" + "\n" + logStr, "Errore");
                            return;
                            //continue;
                        }                        
                    }
                    else if (zoningType == "MANUAL_IBOX" || zoningType == "MANUAL_VSP" || zoningType == "MANUAL_VNX")
                    {
                        try
                        {
                            logStr = "File aperto, Type: " + zoningType + "...";
                            //Estraggo gli swtich della fabric
                            //fabricShow = getFabric(ref fabricCount);
                            //configName.Text = getCfgName(fabricType, swSANiP);

                            if (configName.Text != "")
                            {
                                //WWN HOST
                                hostWWN[1, 0] = hostWWN1;
                                hostWWN[1, 1] = hostName;
                                swHostID = swSANiD;
                                storageNameNew = "";

                                logStr = "File aperto, Estraggo alias storage ...";

                                arrSplitStorage = storageSVM.Split(';');
                                for (i = 0; i < arrSplitStorage.Length; i++)
                                {
                                    arrSplitSVM = arrSplitStorage[i].Split('_');                                    
                                    swStorageID = arrSplitSVM[0].Substring(1);
                                    //logStr += swStorageID + "\n";
                                    storageSVM = arrSplitStorage[i]; //arrSplitSVM[1] + "_" + arrSplitSVM[2] + "_" + arrSplitSVM[3];
                                    //logStr += storageSVM + "\n";
                                    //Estraggo l'alias dello storage
                                    aliasStorageName = searchAliasInFabric(storageSVM, swSANiP);
                                    //Inserisco l'elenco degli alias dei nodi in un array
                                    arrStorage[i] = aliasStorageName[0].Trim();
                                    //logStr += arrStorage[i] + "\n";
                                    storageNameNew = arrSplitSVM[1] + "_" + arrSplitSVM[2];
                                    //logStr += storageNameNew + "\n";
                                }
                                //Creo Alias
                                logStr = "File aperto, Creo/Controllo alias HOST ...";
                                aliHostName = "";
                                //Check se esiste l'alias degli HOST
                                aliasHostName = searchAliasInFabric(hostName, swSANiP);
                                if (aliasHostName[0] == null || aliasHostName[0] == "")
                                {
                                    logStr = "File aperto, Creo alias HOST ...";
                                    dataGridView1.Rows.Add("Alias non esistente, verrà creato...");
                                    //Se l'alias non esiste
                                    aliCreate(hostWWN, storageWWN, swHostID, swStorageID, fabricType, ref aliHostName, swSANiP);
                                    aliasHostName[0] = aliHostName;
                                    if (aliHostName == "")
                                    {
                                        yesno = MessageBox.Show("Problema nella creazione Alias per l'HOST " + hostName + "\n" + "Continuare?", "Errore", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                        if (yesno == DialogResult.Yes)
                                        {
                                            //Continuo con la prossima riga
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        dataGridView1.Rows.Add("Created: " + aliasHostName[0]);
                                        //Creo Zoning
                                        logStr = "File aperto, Alias creato, creo zona ...";
                                        storageSVM = storageNameNew;
                                        storageName = "";
                                        zoneCreateByAlias(aliasHostName, arrStorage, swSANiP, hostName, storageSVM, storageName, fabricType + "" + swSANiD);
                                    }
                                }
                                else
                                {
                                    logStr = "File aperto, Creo zona ...";
                                    //Se l'alias esiste
                                    //aliNameNew = aliasHostName[0].Substring(aliasHostName[0].IndexOf('_') + 1);
                                    //aliNameNew = aliNameNew.Replace(aliNameNew.Substring(aliNameNew.LastIndexOf('_')), "");
                                    //aliasHostName[0] = aliNameNew;
                                    //hostName = aliNameNew;
                                    dataGridView1.Rows.Add("Alias found: " + aliasHostName[0]);
                                    storageSVM = storageNameNew;
                                    storageName = "";
                                    zoneCreateByAlias(aliasHostName, arrStorage, swSANiP, hostName, storageSVM, storageName, fabricType + "" + swSANiD);
                                }
                            }                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + " - Errore in cmdNewZoneFile_Click()" + "\n" + logStr, "Errore");
                            return;
                            //continue;
                        }                        
                    }
                    else if (zoningType == "TEST")
                    {
                        try
                        {
                            logStr = "File aperto, Type: " + zoningType + "...";

                            //MessageBox.Show("cfg: " + configName.Text);
                            if (configName.Text != "")
                            {
                                //WWN HOST
                                hostWWN[1, 0] = hostWWN1;
                                hostWWN[1, 1] = hostName;
                                swHostID = swSANiD;
                                storageNameNew = "";

                                logStr = "File aperto, Estraggo alias storage ...";

                                arrSplitStorage = storageSVM.Split(';');
                                for (i = 0; i < arrSplitStorage.Length; i++)
                                {
                                    arrSplitSVM = arrSplitStorage[i].Split('_');
                                    swStorageID = arrSplitSVM[0].Substring(1);
                                    storageSVM = arrSplitStorage[i]; 
                                    //Estraggo l'alias dello storage
                                    aliasStorageName = searchAliasInFabric(storageSVM, swSANiP);
                                    //Inserisco l'elenco degli alias dei nodi in un array
                                    arrStorage[i] = aliasStorageName[0].Trim();
                                    storageNameNew = arrSplitSVM[1] + "_" + arrSplitSVM[2];
                                }
                                //Creo Alias
                                logStr = "File aperto, Creo/Controllo alias HOST ...";
                                aliHostName = "";
                                //Check se esiste l'alias degli HOST
                                aliasHostName = searchAliasInFabric(hostName, swSANiP);
                                //MessageBox.Show(checkIfArrayNotEmpty(aliasHostName) + "");
                                //MessageBox.Show(aliasHostName[0]);
                                if (aliasHostName[0] == null || aliasHostName[0] == "")
                                {
                                    logStr = "File aperto, Creo alias HOST ...";
                                    dataGridView1.Rows.Add("Alias non esistente, verrà creato...");
                                    //Se l'alias non esiste
                                    //aliCreate(hostWWN, storageWWN, swHostID, swStorageID, fabricType, ref aliHostName, swSANiP);
                                    aliasHostName[0] = aliHostName;
                                    if (aliHostName == "")
                                    {
                                        dataGridView1.Rows.Add("Problema nella creazione Alias...");
                                        yesno = MessageBox.Show("Problema nella creazione Alias per l'HOST " + hostName + "\n" + "Continuare?", "Errore", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                        if (yesno == DialogResult.Yes)
                                        {
                                            //Continuo con la prossima riga
                                        }
                                        else
                                        {
                                            return;
                                        } 
                                    }
                                    else
                                    {
                                        dataGridView1.Rows.Add("Created: " + aliasHostName[0]);
                                        //Creo Zoning
                                        logStr = "File aperto, Alias creato, creo zona ...";
                                        storageSVM = storageNameNew;
                                        storageName = "";
                                        //zoneCreateByAlias(aliasHostName, arrStorage, swSANiP, hostName, storageSVM, storageName, fabricType + "" + swSANiD);
                                    }
                                }
                                else
                                {
                                    logStr = "File aperto, Creo zona ...";
                                    //Se l'alias esiste
                                    dataGridView1.Rows.Add("Alias found: " + aliasHostName[0]);
                                    storageSVM = storageNameNew;
                                    storageName = "";
                                    //zoneCreateByAlias(aliasHostName, arrStorage, swSANiP, hostName, storageSVM, storageName, fabricType + "" + swSANiD);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + " - Errore in cmdNewZoneFile_Click()" + "\n" + logStr, "Errore");
                            return;
                            //continue;
                        }
                    }
                    progressBar1.Value = progressBar1.Value + 1;
                    oldswSANiP = swSANiP;
                    dataGridView1.Refresh();
                    logBox.Refresh();
                    //PrjSAN.ActiveForm.Refresh();
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                    logBox.SelectedIndex = logBox.Items.Count - 1;
                    System.Threading.Thread.Sleep(5000);
                }
                MessageBox.Show("Zoning completed! Check the grid for more information", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string getCfgName(string fabricType, string swSANiP)
        {
            string cmdRun;
            string strCmdText;
            string customOutput;

            try
            {
                int i = 1;
                customOutput = "";
                cmdRun = "cfgshow | grep cfg:";
                strCmdText = "-ssh -batch " + username + "@" + swSANiP + " -pw " + password + " \"" + cmdRun + "\"";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "plink.exe";
                startInfo.Arguments = strCmdText;
                process.StartInfo = startInfo;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;                
                process.Start();
                //process.WaitForExit();
                //process.StandardOutput.ReadToEnd().Replace("alias:", "").Replace("\t", "").Trim();
                while (!process.StandardOutput.EndOfStream)
                {
                    if (i == 4)
                    {
                        customOutput = process.StandardOutput.ReadLine().Replace("\t", "");
                        if (customOutput.IndexOf("cfg:") > 0)
                        {
                            customOutput = process.StandardOutput.ReadLine().Replace("\t", "").Replace(" cfg:", "");
                        }
                        break;
                    }
                    i++;
                }
                process.WaitForExit();
                process.Close();

                if (customOutput == "")
                {
                    //retry
                    customOutput = getCfgName(fabricType, swSANiP);
                }

                return customOutput;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - Errore in getCfgName()", "Errore");
                return "";
                //continue;
            }            
        }

        private void zoneCreateByAlias(string[] aliasHostName, string[] aliasStorageName, string swSANiP, string hostName, string SVMName, string storageName, string swID)
        {
            string cmdRun;
            string strCmdText;
            string customOutput;
            int i;
            string zoneName;
            int elemCount;
            string fileName;
            string strCmdLog;

            //RENCI.SSHNET
            string[] cmdOut = new string[10];
            //string cmdOut;
            SshCommand cmd;
            string result;
            ///

            try
            {
                elemCount = 0;
                for (i = 0; i < aliasStorageName.Length; i++)
                {
                    if (aliasStorageName[i] != null && aliasStorageName[i] != "")
                    {
                        elemCount++;
                    }
                }

                //zoneName = swID + "_" + hostName + "_" + storageName + "_" + SVMName;
                if (storageName != "")
                {
                    zoneName = hostName + "_" + storageName + "_" + SVMName;
                }
                else
                {
                    //hostName = hostName.Replace(hostName.Substring(hostName.LastIndexOf('_')), "");
                    //hostName = aliNameNew;                
                    zoneName = hostName + "_" + SVMName;
                }
                cmdRun = "zonecreate \"" + zoneName + "\", \"" + aliasHostName[0].Replace(" ", "") + ";";
                for (i = 0; i < elemCount; i++)
                {
                    if (i == elemCount - 1)
                    {
                        cmdRun += aliasStorageName[i].Replace(" ", "") + "\"";
                    }
                    else
                    {
                        cmdRun += aliasStorageName[i].Replace(" ", "") + ";";
                    }
                }
                cmdRun += " && cfgadd \"" + configName.Text + "\"" + ", " + "\"" + zoneName + "\"";
                if (swVersion.Text == "7.4.2c")
                {
                    cmdRun += " && cfgsave -f";
                    cmdRun += " && cfgenable -f \"" + configName.Text + "\"";
                }
                else
                {
                    //cmdRun += " && printf \"yes\n\" | cfgsave";
                    cmdRun += " && printf \"yes\n\" | cfgenable \"" + configName.Text + "\"";
                }
                cmdRun = cmdRun.Replace(@"\", "");
                fileName = writeConfigFile(cmdRun);

                strCmdText = "-ssh -batch " + username + "@" + swSANiP + " -pw " + password + " -m " + fileName;
                //strCmdText = "-ssh " + username + "@" + swSANiP + " -pw " + password + " " + cmdRun;
                strCmdLog = "-ssh " + username + "@" + swSANiP + " -pw * -m " + fileName;
                logBox.Items.Add(strCmdLog);
                Console.WriteLine(cmdRun);
                Console.WriteLine(strCmdText);
                /*
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "plink.exe";
                    startInfo.Arguments = strCmdText;
                    process.StartInfo = startInfo;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    //process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.EnableRaisingEvents = true;
                    process.Start();
                    //process.StandardInput.Write("yes");
                    //dataGridView1.Rows.Add(customOutput);
                    //process.WaitForExit();
                
                    process.Exited += (sender, e) => {
                        customOutput = process.StandardOutput.ReadToEnd();
                        dataGridView1.Rows.Add(zoneName);
                        process.Close();
                        dataGridView1.Rows.Add("");
                    };
                */

                /*while (!process.StandardOutput.EndOfStream)
                {
                    customOutput = process.StandardOutput.ReadLine();
                    dataGridView1.Rows.Add(customOutput);
                }*/

                using (var client = new SshClient(swSANiP, username, password))
                {
                    client.Connect();
                    cmd = client.CreateCommand(cmdRun);
                    result = cmd.Execute();
                    Console.WriteLine(cmd);
                    Console.WriteLine(result);
                    logBox.Items.Add(strCmdLog);
                    //cmdOut[0] = result.Replace("alias:", "").Replace("\t", "").Trim();
                    dataGridView1.Rows.Add(result);
                    dataGridView1.Rows.Add(zoneName);
                    client.Disconnect();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - Errore in zoneCreateByAlias()", "Errore");
                return;
                //continue;
            }            

        }

        private string writeConfigFile(string cmdToWrite)
        {
            string path = @"C:\configName.txt";

            if (!File.Exists(path))
            {
                //File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(cmdToWrite);
                tw.Close();
            }
            else if (File.Exists(path))
            {
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(cmdToWrite);
                tw.Close();
            }                

            return path;
        }

        private string[] searchAliasInFabric(string hostName, string swSANiP)
        {
            string cmdRun;
            string strCmdText;
            string[] cmdOut = new string[10];
            //string cmdOut;
            string strCmdLog;
            SshCommand cmd;
            string result;

            try
            {
                cmdRun = "alishow | grep " + hostName + " | grep alias:";
                strCmdLog = "-ssh " + username + "@" + swSANiP + " -pw * \"" + cmdRun + "\"";
                using (var client = new SshClient(swSANiP, username, password))
                {
                    client.Connect();
                    cmd = client.CreateCommand(cmdRun);
                    result = cmd.Execute();
                    Console.WriteLine(cmd);
                    Console.WriteLine(result);
                    logBox.Items.Add(strCmdLog);
                    cmdOut[0] = result.Replace("alias:", "").Replace("\t", "").Trim();
                    client.Disconnect();
                }

                return cmdOut;

                /*
                //Cerco l'alias nella Fabric
                cmdRun = "alishow | grep " + hostName + " | grep alias:";
                strCmdText = "-ssh -batch " + username + "@" + swSANiP + " -pw " + password + " \"" + cmdRun + "\"";
                strCmdLog = "-ssh " + username + "@" + swSANiP + " -pw * \"" + cmdRun + "\"";
                logBox.Items.Add(strCmdLog);
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "plink.exe";
                startInfo.Arguments = strCmdText;
                process.StartInfo = startInfo;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                i = 0;
                while (!process.StandardOutput.EndOfStream)
                {
                    cmdOut[i] = process.StandardOutput.ReadLine().Replace("alias:", "").Replace("\t", "");
                    i++;
                }
                cmdOut[0] = process.StandardOutput.ReadToEnd().Replace("alias:", "").Replace("\t", "").Trim();
                //process.Close();
                process.WaitForExit();
                if (process.HasExited)
                {
                    process.Close();
                    process.Dispose();
                }
                */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - Errore in searchAliasInFabric()", "Errore");
                return cmdOut;
                //continue;
            }            
        }

        private void aliCreate(string[,] hostWWN, string[,] storageWWN, string swHostID, string swStorageID, string fabricType, ref string aliasName, string swSANIP)
        {
            /*alicreate"TANGO_HBA1", "wwn of tango HBA1"
            alicreate"TANGO_HBA3", "wwn of tango HBA3"
            alicreate"ALPHA_CNTLA", "wwn of alpha cntl A"
            alicreate"DELTA_TAPE1", "wwn of Delta tape1"
            zonecreate"TANGO_ALPHA", "TANGO_HBA1; ALPHA_CNTLA"
            zonecreate "TANGO_TAPE", "TANGO_HBA3; DELTA_TAPE1"
            cfgadd "CFG1","TANGO_ALPHA; TANGO_TAPE"( if you have already created config file)
            cfgsave
            cfgenable "CFG1"*/

            string cmdRun;
            string strCmdText;
            string customOutput;
            int i;
            string fileName;
            string strCmdLog;

            //RENCI.SSHNET
            string[] cmdOut = new string[10];
            //string cmdOut;
            SshCommand cmd;
            string result;
            ///

            try
            {
                int elemCount = 1;
                for (i = 1; i < hostWWN.Length; i++)
                {
                    if (hostWWN[i, 0] != null)
                    {
                        elemCount++;
                        break;
                    }
                }

                for (i = 1; i < elemCount; i++)
                {
                    int HostID = Int32.Parse(swHostID);
                    HostID = HostID + 100;
                    if (fabricType == "A")
                    {
                        aliasName = "A" + HostID + "_" + hostWWN[i, 1];
                    }
                    else
                    {
                        aliasName = "B" + HostID + "_" + hostWWN[i, 1];
                    }
                    //nome alias          //WWN 
                    cmdRun = "alicreate " + aliasName + ", " + hostWWN[i, 0];

                    if (swVersion.Text == "7.4.2c")
                    {
                        cmdRun += " && cfgsave -f";
                        cmdRun += " && cfgenable -f";
                    }
                    else
                    {
                        //cmdRun += " && printf \"yes\n\" | cfgsave";
                        cmdRun += " && printf \"yes\n\" | cfgenable \"" + configName.Text + "\"";
                    }
                    fileName = writeConfigFile(cmdRun);
                    strCmdText = "-ssh -batch " + username + "@" + swSANIP + " -pw " + password + " -m " + fileName;
                    //strCmdText = "-ssh " + username + "@" + swSANIP + " -pw " + password + " \"" + cmdRun + "\"";
                    strCmdLog = "-ssh " + username + "@" + swSANIP + " -pw * -m " + fileName;
                    logBox.Items.Add(strCmdText);

                    /*
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "plink.exe";
                        startInfo.Arguments = strCmdText;
                        process.StartInfo = startInfo;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.CreateNoWindow = true;
                        process.EnableRaisingEvents = true;
                        process.Start();
                        //customOutput.Text = process.StandardOutput.ReadToEnd();
                        //while (!process.StandardOutput.EndOfStream)
                        //{
                            //customOutput = process.StandardOutput.ReadLine();
                            //dataGridView1.Rows.Add(customOutput);
                        //}
                        //dataGridView1.Rows.Add(customOutput);
                        //process.WaitForExit();
                    
                        process.Exited += (sender, e) => {
                            customOutput = process.StandardOutput.ReadToEnd();
                            dataGridView1.Rows.Add(customOutput);
                            process.Close();
                        };
                        //process.Close();
                    */

                    using (var client = new SshClient(swSANIP, username, password))
                    {
                        client.Connect();
                        cmd = client.CreateCommand(cmdRun);
                        result = cmd.Execute();
                        Console.WriteLine(cmd);
                        Console.WriteLine(result);
                        logBox.Items.Add(strCmdLog);
                        //cmdOut[0] = result.Replace("alias:", "").Replace("\t", "").Trim();
                        dataGridView1.Rows.Add(result);
                        client.Disconnect();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - Errore in aliCreate()", "Errore");
                //return;
                //continue;
            }                        
        }

        private void aliCreateMoreWWN(string[,] hostWWN, string[,] storageWWN, string swHostID, string swStorageID, string fabricType, ref string aliasName, string swSANIP)
        {           
            /*alicreate"TANGO_HBA1", "wwn of tango HBA1"
            alicreate"TANGO_HBA3", "wwn of tango HBA3"
            alicreate"ALPHA_CNTLA", "wwn of alpha cntl A"
            alicreate"DELTA_TAPE1", "wwn of Delta tape1"
            zonecreate"TANGO_ALPHA", "TANGO_HBA1; ALPHA_CNTLA"
            zonecreate "TANGO_TAPE", "TANGO_HBA3; DELTA_TAPE1"
            cfgadd "CFG1","TANGO_ALPHA; TANGO_TAPE"( if you have already created config file)
            cfgsave
            cfgenable "CFG1"*/

            string cmdRun;
            string strCmdText;
            string customOutput;
            int i;
            string fileName;
            string strCmdLog;

            try
            {
                int elemCount = 1;
                for (i = 1; i < hostWWN.Length; i++)
                {
                    if (hostWWN[i, 0] != null)
                    {
                        elemCount++;
                        break;
                    }
                }

                for (i = 1; i < elemCount; i++)
                {
                    int HostID = Int32.Parse(swHostID);
                    HostID = HostID + 100;
                    if (fabricType == "A")
                    {
                        aliasName = "A" + HostID + "_" + hostWWN[i, 1];
                    }
                    else
                    {
                        aliasName = "B" + HostID + "_" + hostWWN[i, 1];
                    }
                    //nome alias          //WWN                 
                    cmdRun = "alicreate \"" + aliasName + "\", \"" + hostWWN[i, 0] + ";" + hostWWN[i, 2] + "\"";
                    if (swVersion.Text == "7.4.2c")
                    {
                        cmdRun += " && cfgsave -f";
                    }
                    else
                    {
                        cmdRun += " && echo yes | cfgsave";
                    }

                    try
                    {
                        //fileName = writeConfigFile(cmdRun);
                        fileName = writeConfigFile(cmdRun);
                        strCmdText = "-ssh -batch " + username + "@" + swSANIP + " -pw " + password + " -m " + fileName;
                        //strCmdText = "-ssh " + username + "@" + swSANIP + " -pw " + password + " \"" + cmdRun + "\"";
                        strCmdLog = "-ssh " + username + "@" + swSANIP + " -pw * -m " + fileName;
                        logBox.Items.Add(strCmdLog);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "plink.exe";
                        startInfo.Arguments = strCmdText;
                        process.StartInfo = startInfo;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.CreateNoWindow = true;
                        process.Start();
                        process.WaitForExit();
                        //customOutput.Text = process.StandardOutput.ReadToEnd();
                        while (!process.StandardOutput.EndOfStream)
                        {
                            customOutput = process.StandardOutput.ReadLine();
                            dataGridView1.Rows.Add(customOutput);
                        }
                        process.Close();
                    }
                    catch (Exception excep)
                    {
                        aliasName = "";
                        MessageBox.Show(excep.Message + " - Errore in aliCreateMoreWWN()", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - Errore in aliCreateMoreWWN()", "Errore");
                return;
                //continue;
            }            
        }

        private string[,] searchPortInFabric(string swIP, string nameToSearch)
        {
            string[,] portWWN = new string[10, 10];
            string cmdRun;
            string strCmdText;
            string customOutput;
            string[] outArray = new string[50];
            string portNumber;
            string portName;
            string strCmdLog;

            customOutput = "";
            int c = 1;
            cmdRun = "portname | grep " + nameToSearch;
            strCmdText = "-ssh -batch " + username + "@" + swIP + " -pw " + password + " \"" + cmdRun + "\"";
            strCmdLog = "-ssh " + username + "@" + swIP + " -pw * \"" + cmdRun + "\"";
            logBox.Items.Add(strCmdText);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "plink.exe";
            startInfo.Arguments = strCmdText;
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
            //Estraggo il numero delle porte    
            while (!process.StandardOutput.EndOfStream)
            {
                customOutput = process.StandardOutput.ReadLine();
                if (customOutput != "")
                {
                    //Estraggo il numero della porta
                    outArray = customOutput.Split(':');
                    portNumber = outArray[0].Trim();
                    portName = outArray[1].Trim();
                    portNumber = portNumber.Replace(" ", ";");
                    outArray = portNumber.Split(';');
                    if (outArray[1] != "")
                    {
                        portNumber = outArray[1];
                    }
                    else
                    {
                        portNumber = outArray[2];
                    }

                    cmdRun = "portshow " + portNumber + " | grep portWwn -1";
                    strCmdText = "-ssh -batch " + username + "@" + swIP + " -pw " + password + " \"" + cmdRun + "\"";
                    strCmdLog = "-ssh " + username + "@" + swIP + " -pw * \"" + cmdRun + "\"";
                    logBox.Items.Add(strCmdLog);

                    System.Diagnostics.Process processS = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfoS = new System.Diagnostics.ProcessStartInfo();
                    startInfoS.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfoS.FileName = "plink.exe";
                    startInfoS.Arguments = strCmdText;
                    processS.StartInfo = startInfoS;
                    processS.StartInfo.UseShellExecute = false;
                    processS.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;
                    processS.Start();
                    process.WaitForExit();
                    //customOutput = processS.StandardOutput.ReadToEnd();
                    int i = 1;                    
                    while (!processS.StandardOutput.EndOfStream)
                    {
                        customOutput = processS.StandardOutput.ReadLine();
                        if (i == 4)
                        {
                            portWWN[c, 0] = customOutput.Trim().Replace("\t", "");
                            portWWN[c, 1] = portName.Trim();
                            c++;
                        }
                        i++;
                    }
                }
            }                      

            return portWWN;
        }

        private string[] getFabric(ref int count)
        {
            string cmdRun;
            string strCmdText;
            string[] outputF = new string[50];
            string outputFabric;
            string swID;
            string swIP;
            string strCmdLog;

            try
            {
                count = 0;
                //Estraggo l'elenco degli switch da interrogare
                cmdRun = "fabricshow";
                strCmdText = "-ssh -batch " + username + "@" + ipUsed + " -pw " + password + " \"" + cmdRun + "\"";
                strCmdLog = "-ssh " + username + "@" + ipUsed + " -pw * \"" + cmdRun + "\"";
                logBox.Items.Add(strCmdLog);
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "plink.exe";
                startInfo.Arguments = strCmdText;
                process.StartInfo = startInfo;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();
                //outputF = process.StandardOutput.ReadToEnd();            
                int i = 1;
                //int count = 0;
                while (!process.StandardOutput.EndOfStream)
                {
                    outputFabric = process.StandardOutput.ReadLine().Replace(" ", ";");
                    //Console.WriteLine(outputFabric);
                    if (i >= 3)
                    {
                        if (outputFabric != "")
                        {
                            if (outputFabric.Length > 52)
                            {
                                //outputFabric = outputFabric.Substring(0, 52);
                                //Console.WriteLine(outputFabric);
                                if (outputFabric.Substring(0, 2) == ";;")
                                {
                                    //Se uguale a ;;
                                    outputFabric = outputFabric.Substring(0, 52);
                                    Console.WriteLine(outputFabric);
                                }
                                else if (outputFabric.Substring(0, 1) == ";")
                                {
                                    outputFabric = outputFabric.Substring(1, 51);
                                    Console.WriteLine(outputFabric);
                                }
                                else if (outputFabric.Substring(0, 1) != ";")
                                {
                                    outputFabric = outputFabric.Substring(0, 51);
                                    Console.WriteLine(outputFabric);
                                }
                                outputFabric = outputFabric.Replace(";;", "");
                                Console.WriteLine(outputFabric);
                                var arrZone = outputFabric.Split(';');
                                swID = arrZone[0].Replace(":", "");
                                swIP = arrZone[3];
                                //swName = arrZone[5];
                                //dataGridView1.Rows.Add(swID + ";" + swIP);
                                outputF[count] = swID + ";" + swIP;
                                count++;
                            }
                        }
                    }
                    i++;
                }

                return outputF;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - Errore in getFabric()", "Errore");
                return outputF;
                //continue;
            }                      
        }

        private int checkIfArrayNotEmpty(string[] array)
        {
            int elemCount;
            int i;

            elemCount = 0;
            for (i = 0; i < array.Length; i++)
            {
                dataGridView1.Rows.Add(array[i]);
                if (array[i] != null && array[i] != "")
                {
                    elemCount++;
                    dataGridView1.Rows.Add(array[i]);
                }
            }

            return elemCount;
        }

        private void swVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void openDocumentation_Click(object sender, EventArgs e)
        {
            try
            {
                //Apro documento di help
                System.Diagnostics.Process.Start(@"\\itpmfss100\Repository\Managed Operations\Server&Storage Mngt\STORAGE\Docs_Operativi\BROCADE\Zoning_automatizzato\zoning_automatico_prjSAN.docx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - Errore in openDocumentation_Click()", "Errore");
            }
        }
    }
}
