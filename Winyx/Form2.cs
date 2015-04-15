using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Winyx
{
    public partial class Form2 : Form
    {
        // The path to the registry key where Windows looks for startup applications (current user only)
        RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        DataHandler data;
        Form1 main;

        public Form2(Form1 m)
        {
            InitializeComponent();
            // Check if already running in startup
            if (rk.GetValue("Window Management Tool") != null)
            {
                // If exists, tick the checkbox.
                chkStartup.Checked = true;
            }
            main = m;
            data = main.Data;
            populateHotkeys();  
                      
        }

        private void populateHotkeys() {
            cK_ADToggle.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_ADToggle.DisplayMember = "Value";
            cK_ADToggle.ValueMember = "Key";

            cK_ADUp.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_ADUp.DisplayMember = "Value";
            cK_ADUp.ValueMember = "Key";

            cK_ADDown.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_ADDown.DisplayMember = "Value";
            cK_ADDown.ValueMember = "Key";

            cK_ADLeft.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_ADLeft.DisplayMember = "Value";
            cK_ADLeft.ValueMember = "Key";

            cK_ADRight.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_ADRight.DisplayMember = "Value";
            cK_ADRight.ValueMember = "Key";

            cK_Restore.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_Restore.DisplayMember = "Value";
            cK_Restore.ValueMember = "Key";

            cK_MWUp.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_MWUp.DisplayMember = "Value";
            cK_MWUp.ValueMember = "Key";

            cK_MWDown.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_MWDown.DisplayMember = "Value";
            cK_MWDown.ValueMember = "Key";

            cK_MWLeft.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_MWLeft.DisplayMember = "Value";
            cK_MWLeft.ValueMember = "Key";

            cK_MWRight.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_MWRight.DisplayMember = "Value";
            cK_MWRight.ValueMember = "Key";

            cK_GW.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_GW.DisplayMember = "Value";
            cK_GW.ValueMember = "Key";

            cK_SW.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SW.DisplayMember = "Value";
            cK_SW.ValueMember = "Key";

            cK_SWM.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SWM.DisplayMember = "Value";
            cK_SWM.ValueMember = "Key";

            cK_AAA.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AAA.DisplayMember = "Value";
            cK_AAA.ValueMember = "Key";

            cK_AC1.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AC1.DisplayMember = "Value";
            cK_AC1.ValueMember = "Key";

            cK_AC2.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AC2.DisplayMember = "Value";
            cK_AC2.ValueMember = "Key";

            cK_AC3.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AC3.DisplayMember = "Value";
            cK_AC3.ValueMember = "Key";

            cK_AC4.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AC4.DisplayMember = "Value";
            cK_AC4.ValueMember = "Key";

            cK_AC5.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AC5.DisplayMember = "Value";
            cK_AC5.ValueMember = "Key";

            cK_AC6.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AC6.DisplayMember = "Value";
            cK_AC6.ValueMember = "Key";

            cK_AC7.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AC7.DisplayMember = "Value";
            cK_AC7.ValueMember = "Key";

            cK_AC8.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AC8.DisplayMember = "Value";
            cK_AC8.ValueMember = "Key";

            cK_AC9.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AC9.DisplayMember = "Value";
            cK_AC9.ValueMember = "Key";

            cK_AtC1.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AtC1.DisplayMember = "Value";
            cK_AtC1.ValueMember = "Key";

            cK_AtC2.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AtC2.DisplayMember = "Value";
            cK_AtC2.ValueMember = "Key";

            cK_AtC3.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AtC3.DisplayMember = "Value";
            cK_AtC3.ValueMember = "Key";

            cK_AtC4.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AtC4.DisplayMember = "Value";
            cK_AtC4.ValueMember = "Key";

            cK_AtC5.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AtC5.DisplayMember = "Value";
            cK_AtC5.ValueMember = "Key";

            cK_AtC6.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AtC6.DisplayMember = "Value";
            cK_AtC6.ValueMember = "Key";

            cK_AtC7.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AtC7.DisplayMember = "Value";
            cK_AtC7.ValueMember = "Key";

            cK_AtC8.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AtC8.DisplayMember = "Value";
            cK_AtC8.ValueMember = "Key";

            cK_AtC9.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_AtC9.DisplayMember = "Value";
            cK_AtC9.ValueMember = "Key";

            cK_CAW.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_CAW.DisplayMember = "Value";
            cK_CAW.ValueMember = "Key";

            cK_CC1.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_CC1.DisplayMember = "Value";
            cK_CC1.ValueMember = "Key";

            cK_CC2.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_CC2.DisplayMember = "Value";
            cK_CC2.ValueMember = "Key";

            cK_CC3.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_CC3.DisplayMember = "Value";
            cK_CC3.ValueMember = "Key";

            cK_CC4.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_CC4.DisplayMember = "Value";
            cK_CC4.ValueMember = "Key";

            cK_CC5.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_CC5.DisplayMember = "Value";
            cK_CC5.ValueMember = "Key";

            cK_CC6.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_CC6.DisplayMember = "Value";
            cK_CC6.ValueMember = "Key";

            cK_CC7.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_CC7.DisplayMember = "Value";
            cK_CC7.ValueMember = "Key";

            cK_CC8.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_CC8.DisplayMember = "Value";
            cK_CC8.ValueMember = "Key";

            cK_CC9.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_CC9.DisplayMember = "Value";
            cK_CC9.ValueMember = "Key";

            cK_KAW.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_KAW.DisplayMember = "Value";
            cK_KAW.ValueMember = "Key";

            cK_KC1.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_KC1.DisplayMember = "Value";
            cK_KC1.ValueMember = "Key";

            cK_KC2.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_KC2.DisplayMember = "Value";
            cK_KC2.ValueMember = "Key";

            cK_KC3.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_KC3.DisplayMember = "Value";
            cK_KC3.ValueMember = "Key";

            cK_KC4.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_KC4.DisplayMember = "Value";
            cK_KC4.ValueMember = "Key";

            cK_KC5.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_KC5.DisplayMember = "Value";
            cK_KC5.ValueMember = "Key";

            cK_KC6.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_KC6.DisplayMember = "Value";
            cK_KC6.ValueMember = "Key";

            cK_KC7.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_KC7.DisplayMember = "Value";
            cK_KC7.ValueMember = "Key";

            cK_KC8.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_KC8.DisplayMember = "Value";
            cK_KC8.ValueMember = "Key";

            cK_KC9.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_KC9.DisplayMember = "Value";
            cK_KC9.ValueMember = "Key";

            cK_SAW.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SAW.DisplayMember = "Value";
            cK_SAW.ValueMember = "Key";

            cK_SC1.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SC1.DisplayMember = "Value";
            cK_SC1.ValueMember = "Key";

            cK_SC2.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SC2.DisplayMember = "Value";
            cK_SC2.ValueMember = "Key";

            cK_SC3.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SC3.DisplayMember = "Value";
            cK_SC3.ValueMember = "Key";

            cK_SC4.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SC4.DisplayMember = "Value";
            cK_SC4.ValueMember = "Key";

            cK_SC5.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SC5.DisplayMember = "Value";
            cK_SC5.ValueMember = "Key";

            cK_SC6.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SC6.DisplayMember = "Value";
            cK_SC6.ValueMember = "Key";

            cK_SC7.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SC7.DisplayMember = "Value";
            cK_SC7.ValueMember = "Key";

            cK_SC8.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SC8.DisplayMember = "Value";
            cK_SC8.ValueMember = "Key";

            cK_SC9.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_SC9.DisplayMember = "Value";
            cK_SC9.ValueMember = "Key";

            cK_HAW.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_HAW.DisplayMember = "Value";
            cK_HAW.ValueMember = "Key";

            cK_HC1.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_HC1.DisplayMember = "Value";
            cK_HC1.ValueMember = "Key";

            cK_HC2.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_HC2.DisplayMember = "Value";
            cK_HC2.ValueMember = "Key";

            cK_HC3.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_HC3.DisplayMember = "Value";
            cK_HC3.ValueMember = "Key";

            cK_HC4.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_HC4.DisplayMember = "Value";
            cK_HC4.ValueMember = "Key";

            cK_HC5.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_HC5.DisplayMember = "Value";
            cK_HC5.ValueMember = "Key";

            cK_HC6.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_HC6.DisplayMember = "Value";
            cK_HC6.ValueMember = "Key";

            cK_HC7.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_HC7.DisplayMember = "Value";
            cK_HC7.ValueMember = "Key";

            cK_HC8.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_HC8.DisplayMember = "Value";
            cK_HC8.ValueMember = "Key";

            cK_HC9.DataSource = Enum.GetValues(typeof(Keys))
            .Cast<Keys>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();
            cK_HC9.DisplayMember = "Value";
            cK_HC9.ValueMember = "Key";

            // AUTODOCK HOTKEYS
            cK_ADToggle.Text = data.GetKey("AutodockToggle").ToString();
            cM_ADToggle.SelectedIndex = data.GetMod("AutodockToggle");

            cK_ADUp.Text = data.GetKey("DockUp").ToString();
            cM_ADUp.SelectedIndex = data.GetMod("DockUp");

            cK_ADDown.Text = data.GetKey("DockDown").ToString();
            cM_ADDown.SelectedIndex = data.GetMod("DockDown");

            cK_ADLeft.Text = data.GetKey("DockLeft").ToString();
            cM_ADLeft.SelectedIndex = data.GetMod("DockLeft");

            cK_ADRight.Text = data.GetKey("DockRight").ToString();
            cM_ADRight.SelectedIndex = data.GetMod("DockRight");

            cK_Restore.Text = data.GetKey("Restore").ToString();
            cM_Restore.SelectedIndex = data.GetMod("Restore");

            cM_SDM.SelectedIndex = data.GetMod("DockAlt");

            // WINDOW MANIPULATION HOTKEYS
            cK_MWUp.Text = data.GetKey("MoveUp").ToString();
            cM_MWUp.SelectedIndex = data.GetMod("MoveUp");

            cK_MWDown.Text = data.GetKey("MoveDown").ToString();
            cM_MWDown.SelectedIndex = data.GetMod("MoveDown");

            cK_MWLeft.Text = data.GetKey("MoveLeft").ToString();
            cM_MWLeft.SelectedIndex = data.GetMod("MoveLeft");

            cK_MWRight.Text = data.GetKey("MoveRight").ToString();
            cM_MWRight.SelectedIndex = data.GetMod("MoveRight");

            cK_GW.Text = data.GetKey("SizeUp").ToString();
            cM_GW.SelectedIndex = data.GetMod("SizeUp");

            cK_SW.Text = data.GetKey("SizeDown").ToString();
            cM_SW.SelectedIndex = data.GetMod("SizeDown");

            cK_SWM.Text = data.GetKey("SwapMainWindow").ToString();
            cM_SWM.SelectedIndex = data.GetMod("SwapMainWindow");

            // ARRANGE HOTKEYS
            cK_AAA.Text = data.GetKey("ArrangeAll").ToString();
            cM_AAA.SelectedIndex = data.GetMod("ArrangeAll");

            cK_AC1.Text = data.GetKey("ArrangeCategory1").ToString();
            cM_AC1.SelectedIndex = data.GetMod("ArrangeCategory1");

            cK_AC2.Text = data.GetKey("ArrangeCategory2").ToString();
            cM_AC2.SelectedIndex = data.GetMod("ArrangeCategory2");

            cK_AC3.Text = data.GetKey("ArrangeCategory3").ToString();
            cM_AC3.SelectedIndex = data.GetMod("ArrangeCategory3");

            cK_AC4.Text = data.GetKey("ArrangeCategory4").ToString();
            cM_AC4.SelectedIndex = data.GetMod("ArrangeCategory4");

            cK_AC5.Text = data.GetKey("ArrangeCategory5").ToString();
            cM_AC5.SelectedIndex = data.GetMod("ArrangeCategory5");

            cK_AC6.Text = data.GetKey("ArrangeCategory6").ToString();
            cM_AC6.SelectedIndex = data.GetMod("ArrangeCategory6");

            cK_AC7.Text = data.GetKey("ArrangeCategory7").ToString();
            cM_AC7.SelectedIndex = data.GetMod("ArrangeCategory7");

            cK_AC8.Text = data.GetKey("ArrangeCategory8").ToString();
            cM_AC8.SelectedIndex = data.GetMod("ArrangeCategory8");

            cK_AC9.Text = data.GetKey("ArrangeCategory9").ToString();
            cM_AC9.SelectedIndex = data.GetMod("ArrangeCategory9");

            // ADD HOTKEYS
            cK_AtC1.Text = data.GetKey("AddToCategory1").ToString();
            cM_AtC1.SelectedIndex = data.GetMod("AddToCategory1");

            cK_AtC2.Text = data.GetKey("AddToCategory2").ToString();
            cM_AtC2.SelectedIndex = data.GetMod("AddToCategory2");

            cK_AtC3.Text = data.GetKey("AddToCategory3").ToString();
            cM_AtC3.SelectedIndex = data.GetMod("AddToCategory3");

            cK_AtC4.Text = data.GetKey("AddToCategory4").ToString();
            cM_AtC4.SelectedIndex = data.GetMod("AddToCategory4");

            cK_AtC5.Text = data.GetKey("AddToCategory5").ToString();
            cM_AtC5.SelectedIndex = data.GetMod("AddToCategory5");

            cK_AtC6.Text = data.GetKey("AddToCategory6").ToString();
            cM_AtC6.SelectedIndex = data.GetMod("AddToCategory6");

            cK_AtC7.Text = data.GetKey("AddToCategory7").ToString();
            cM_AtC7.SelectedIndex = data.GetMod("AddToCategory7");

            cK_AtC8.Text = data.GetKey("AddToCategory8").ToString();
            cM_AtC8.SelectedIndex = data.GetMod("AddToCategory8");

            cK_AtC9.Text = data.GetKey("AddToCategory9").ToString();
            cM_AtC9.SelectedIndex = data.GetMod("AddToCategory9");

            // CLOSE HOTKEYS
            cK_CAW.Text = data.GetKey("CloseAll").ToString();
            cM_CAW.SelectedIndex = data.GetMod("CloseAll");

            cK_CC1.Text = data.GetKey("CloseCategory1").ToString();
            cM_CC1.SelectedIndex = data.GetMod("CloseCategory1");

            cK_CC2.Text = data.GetKey("CloseCategory2").ToString();
            cM_CC2.SelectedIndex = data.GetMod("CloseCategory2");

            cK_CC3.Text = data.GetKey("CloseCategory3").ToString();
            cM_CC3.SelectedIndex = data.GetMod("CloseCategory3");

            cK_CC4.Text = data.GetKey("CloseCategory4").ToString();
            cM_CC4.SelectedIndex = data.GetMod("CloseCategory4");

            cK_CC5.Text = data.GetKey("CloseCategory5").ToString();
            cM_CC5.SelectedIndex = data.GetMod("CloseCategory5");

            cK_CC6.Text = data.GetKey("CloseCategory6").ToString();
            cM_CC6.SelectedIndex = data.GetMod("CloseCategory6");

            cK_CC7.Text = data.GetKey("CloseCategory7").ToString();
            cM_CC7.SelectedIndex = data.GetMod("CloseCategory7");

            cK_CC8.Text = data.GetKey("CloseCategory8").ToString();
            cM_CC8.SelectedIndex = data.GetMod("CloseCategory8");

            cK_CC9.Text = data.GetKey("CloseCategory9").ToString();
            cM_CC9.SelectedIndex = data.GetMod("CloseCategory9");

            // KILL HOTKEYS
            cK_KAW.Text = data.GetKey("KillAll").ToString();
            cM_KAW.SelectedIndex = data.GetMod("KillAll");

            cK_KC1.Text = data.GetKey("KillCategory1").ToString();
            cM_KC1.SelectedIndex = data.GetMod("KillCategory1");

            cK_KC2.Text = data.GetKey("KillCategory2").ToString();
            cM_KC2.SelectedIndex = data.GetMod("KillCategory2");

            cK_KC3.Text = data.GetKey("KillCategory3").ToString();
            cM_KC3.SelectedIndex = data.GetMod("KillCategory3");

            cK_KC4.Text = data.GetKey("KillCategory4").ToString();
            cM_KC4.SelectedIndex = data.GetMod("KillCategory4");

            cK_KC5.Text = data.GetKey("KillCategory5").ToString();
            cM_KC5.SelectedIndex = data.GetMod("KillCategory5");

            cK_KC6.Text = data.GetKey("KillCategory6").ToString();
            cM_KC6.SelectedIndex = data.GetMod("KillCategory6");

            cK_KC7.Text = data.GetKey("KillCategory7").ToString();
            cM_KC7.SelectedIndex = data.GetMod("KillCategory7");

            cK_KC8.Text = data.GetKey("KillCategory8").ToString();
            cM_KC8.SelectedIndex = data.GetMod("KillCategory8");

            cK_KC9.Text = data.GetKey("KillCategory9").ToString();
            cM_KC9.SelectedIndex = data.GetMod("KillCategory9");

            // SHOW HOTKEYS
            cK_SAW.Text = data.GetKey("ShowAll").ToString();
            cM_SAW.SelectedIndex = data.GetMod("ShowAll");

            cK_SC1.Text = data.GetKey("ShowCategory1").ToString();
            cM_SC1.SelectedIndex = data.GetMod("ShowCategory1");

            cK_SC2.Text = data.GetKey("ShowCategory2").ToString();
            cM_SC2.SelectedIndex = data.GetMod("ShowCategory2");

            cK_SC3.Text = data.GetKey("ShowCategory3").ToString();
            cM_SC3.SelectedIndex = data.GetMod("ShowCategory3");

            cK_SC4.Text = data.GetKey("ShowCategory4").ToString();
            cM_SC4.SelectedIndex = data.GetMod("ShowCategory4");

            cK_SC5.Text = data.GetKey("ShowCategory5").ToString();
            cM_SC5.SelectedIndex = data.GetMod("ShowCategory5");

            cK_SC6.Text = data.GetKey("ShowCategory6").ToString();
            cM_SC6.SelectedIndex = data.GetMod("ShowCategory6");

            cK_SC7.Text = data.GetKey("ShowCategory7").ToString();
            cM_SC7.SelectedIndex = data.GetMod("ShowCategory7");

            cK_SC8.Text = data.GetKey("ShowCategory8").ToString();
            cM_SC8.SelectedIndex = data.GetMod("ShowCategory8");

            cK_SC9.Text = data.GetKey("ShowCategory9").ToString();
            cM_SC9.SelectedIndex = data.GetMod("ShowCategory9");

            // HIDE HOTKEYS
            cK_HAW.Text = data.GetKey("HideAll").ToString();
            cM_HAW.SelectedIndex = data.GetMod("HideAll");

            cK_HC1.Text = data.GetKey("HideCategory1").ToString();
            cM_HC1.SelectedIndex = data.GetMod("HideCategory1");

            cK_HC2.Text = data.GetKey("HideCategory2").ToString();
            cM_HC2.SelectedIndex = data.GetMod("HideCategory2");

            cK_HC3.Text = data.GetKey("HideCategory3").ToString();
            cM_HC3.SelectedIndex = data.GetMod("HideCategory3");

            cK_HC4.Text = data.GetKey("HideCategory4").ToString();
            cM_HC4.SelectedIndex = data.GetMod("HideCategory4");

            cK_HC5.Text = data.GetKey("HideCategory5").ToString();
            cM_HC5.SelectedIndex = data.GetMod("HideCategory5");

            cK_HC6.Text = data.GetKey("HideCategory6").ToString();
            cM_HC6.SelectedIndex = data.GetMod("HideCategory6");

            cK_HC7.Text = data.GetKey("HideCategory7").ToString();
            cM_HC7.SelectedIndex = data.GetMod("HideCategory7");

            cK_HC8.Text = data.GetKey("HideCategory8").ToString();
            cM_HC8.SelectedIndex = data.GetMod("HideCategory8");

            cK_HC9.Text = data.GetKey("HideCategory9").ToString();
            cM_HC9.SelectedIndex = data.GetMod("HideCategory9");
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkStartup.Checked)
            {
                // Add the value in the registry
                rk.SetValue("Window Management Tool", Application.ExecutablePath.ToString());
            }
            else
            {
                // Remove the value from the registry
                rk.DeleteValue("Window Management Tool", false);
            }
            // SAVE HOTKEYS TO XML
            DataHandler.SaveData(cM_MWUp.SelectedIndex.ToString(), cK_MWUp.Text, cM_MWDown.SelectedIndex.ToString(), cK_MWDown.Text, cM_MWLeft.SelectedIndex.ToString(), cK_MWLeft.Text, cM_MWRight.SelectedIndex.ToString(), cK_MWRight.Text,
                cM_GW.SelectedIndex.ToString(), cK_GW.Text, cM_SW.SelectedIndex.ToString(), cK_SW.Text, cM_AAA.SelectedIndex.ToString(), cK_AAA.Text,
                cM_AC1.SelectedIndex.ToString(), cK_AC1.Text, cM_AC2.SelectedIndex.ToString(), cK_AC2.Text, cM_AC3.SelectedIndex.ToString(), cK_AC3.Text, cM_AC4.SelectedIndex.ToString(), cK_AC4.Text,
                cM_AC5.SelectedIndex.ToString(), cK_AC5.Text, cM_AC6.SelectedIndex.ToString(), cK_AC6.Text, cM_AC7.SelectedIndex.ToString(), cK_AC7.Text, cM_AC8.SelectedIndex.ToString(), cK_AC8.Text,
                cM_AC9.SelectedIndex.ToString(), cK_AC9.Text, cM_CAW.SelectedIndex.ToString(), cK_CAW.Text, cM_CC1.SelectedIndex.ToString(), cK_CC1.Text, cM_CC2.SelectedIndex.ToString(), cK_CC2.Text,
                cM_CC3.SelectedIndex.ToString(), cK_CC3.Text, cM_CC4.SelectedIndex.ToString(), cK_CC4.Text, cM_CC5.SelectedIndex.ToString(), cK_CC5.Text, cM_CC6.SelectedIndex.ToString(), cK_CC6.Text,
                cM_CC7.SelectedIndex.ToString(), cK_CC7.Text, cM_CC8.SelectedIndex.ToString(), cK_CC8.Text, cM_CC9.SelectedIndex.ToString(), cK_CC9.Text, cM_KAW.SelectedIndex.ToString(), cK_KAW.Text,
                cM_KC1.SelectedIndex.ToString(), cK_KC1.Text, cM_KC2.SelectedIndex.ToString(), cK_KC2.Text, cM_KC3.SelectedIndex.ToString(), cK_KC3.Text, cM_KC4.SelectedIndex.ToString(), cK_KC4.Text,
                cM_KC5.SelectedIndex.ToString(), cK_KC5.Text, cM_KC6.SelectedIndex.ToString(), cK_KC6.Text, cM_KC7.SelectedIndex.ToString(), cK_KC7.Text, cM_KC8.SelectedIndex.ToString(), cK_KC8.Text,
                cM_KC9.SelectedIndex.ToString(), cK_KC9.Text, cM_AtC1.SelectedIndex.ToString(), cK_AtC1.Text, cM_AtC2.SelectedIndex.ToString(), cK_AtC2.Text, cM_AtC3.SelectedIndex.ToString(), cK_AtC3.Text,
                cM_AtC4.SelectedIndex.ToString(), cK_AtC4.Text, cM_AtC5.SelectedIndex.ToString(), cK_AtC5.Text, cM_AtC6.SelectedIndex.ToString(), cK_AtC6.Text, cM_AtC7.SelectedIndex.ToString(), cK_AtC7.Text,
                cM_AtC8.SelectedIndex.ToString(), cK_AtC8.Text, cM_AtC9.SelectedIndex.ToString(), cK_AtC9.Text, cM_ADToggle.SelectedIndex.ToString(), cK_ADToggle.Text, cM_ADUp.SelectedIndex.ToString(), cK_ADUp.Text,
                cM_ADDown.SelectedIndex.ToString(), cK_ADDown.Text, cM_ADLeft.SelectedIndex.ToString(), cK_ADLeft.Text, cM_ADRight.SelectedIndex.ToString(), cK_ADRight.Text, cM_SDM.SelectedIndex.ToString(), cM_SAW.SelectedIndex.ToString(), cK_SAW.Text,
                cM_SC1.SelectedIndex.ToString(), cK_SC1.Text, cM_SC2.SelectedIndex.ToString(), cK_SC2.Text, cM_SC3.SelectedIndex.ToString(), cK_SC3.Text, cM_SC4.SelectedIndex.ToString(), cK_SC4.Text,
                cM_SC5.SelectedIndex.ToString(), cK_SC5.Text, cM_SC6.SelectedIndex.ToString(), cK_SC6.Text, cM_SC7.SelectedIndex.ToString(), cK_SC7.Text, cM_SC8.SelectedIndex.ToString(), cK_SC8.Text,
                cM_SC9.SelectedIndex.ToString(), cK_SC9.Text, cM_HAW.SelectedIndex.ToString(), cK_HAW.Text, cM_HC1.SelectedIndex.ToString(), cK_HC1.Text, cM_HC2.SelectedIndex.ToString(), cK_HC2.Text,
                cM_HC3.SelectedIndex.ToString(), cK_HC3.Text, cM_HC4.SelectedIndex.ToString(), cK_HC4.Text, cM_HC5.SelectedIndex.ToString(), cK_HC5.Text, cM_HC6.SelectedIndex.ToString(), cK_HC6.Text,
                cM_HC7.SelectedIndex.ToString(), cK_HC7.Text, cM_HC8.SelectedIndex.ToString(), cK_HC8.Text, cM_HC9.SelectedIndex.ToString(), cK_HC9.Text, cM_Restore.SelectedIndex.ToString(), cK_Restore.Text, cM_SWM.SelectedIndex.ToString(), cK_SWM.Text);
            main.UnregisterAllHotkeys();
            main.LoadXML();
            main.AssignHotkeys();
            main.RegisterAllHotkeys();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            populateHotkeys();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
