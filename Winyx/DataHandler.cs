using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Winyx
{
    class DataHandler
    {
        private XDocument Document;

        public DataHandler(XDocument doc)
        {
            Document = doc;
        }

        public static void InitializeData() {
            XDocument hotkeyData = new XDocument(
                    new XDeclaration("1.0","utf8","yes"),
                    new XComment("Keybinds for Window Management Tool"),

                    new XElement("Hotkeys",
                        new XElement("MoveUp", 
                            new XElement("Modifier", HotkeyConstants.SHIFT.ToString()),
                            new XElement("Key", Keys.Up.ToString())
                            ),
                        new XElement("MoveDown",
                            new XElement("Modifier", HotkeyConstants.SHIFT.ToString()),
                            new XElement("Key", Keys.Down.ToString())
                            ),
                        new XElement("MoveLeft",
                            new XElement("Modifier", HotkeyConstants.SHIFT.ToString()),
                            new XElement("Key", Keys.Left.ToString())
                            ),
                        new XElement("MoveRight",
                            new XElement("Modifier", HotkeyConstants.SHIFT.ToString()),
                            new XElement("Key", Keys.Right.ToString())
                            ),
                        new XElement("SizeUp",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.Up.ToString())
                            ),
                        new XElement("SizeDown",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.Down.ToString())
                            ),
                        new XElement("ArrangeAll",
                            new XElement("Modifier", (HotkeyConstants.WIN).ToString()),
                            new XElement("Key", Keys.A.ToString())
                            ),
                        new XElement("ArrangeCategory1",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D1.ToString())
                            ),
                        new XElement("ArrangeCategory2",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D2.ToString())
                            ),
                        new XElement("ArrangeCategory3",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D3.ToString())
                            ),
                        new XElement("ArrangeCategory4",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D4.ToString())
                            ),
                        new XElement("ArrangeCategory5",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D5.ToString())
                            ),
                        new XElement("ArrangeCategory6",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D6.ToString())
                            ),
                        new XElement("ArrangeCategory7",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D7.ToString())
                            ),
                        new XElement("ArrangeCategory8",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D8.ToString())
                            ),
                        new XElement("ArrangeCategory9",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D9.ToString())
                            ),
                        new XElement("CloseAll",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.End.ToString())
                            ),
                        new XElement("CloseCategory1",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D1.ToString())
                            ),
                        new XElement("CloseCategory2",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D2.ToString())
                            ),
                        new XElement("CloseCategory3",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D3.ToString())
                            ),
                        new XElement("CloseCategory4",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D4.ToString())
                            ),
                        new XElement("CloseCategory5",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D5.ToString())
                            ),
                        new XElement("CloseCategory6",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D6.ToString())
                            ),
                        new XElement("CloseCategory7",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D7.ToString())
                            ),
                        new XElement("CloseCategory8",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D8.ToString())
                            ),
                        new XElement("CloseCategory9",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D9.ToString())
                            ),
                        new XElement("KillAll",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.End.ToString())
                            ),
                        new XElement("KillCategory1",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D1.ToString())
                            ),
                        new XElement("KillCategory2",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D2.ToString())
                            ),
                        new XElement("KillCategory3",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D3.ToString())
                            ),
                        new XElement("KillCategory4",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D4.ToString())
                            ),
                        new XElement("KillCategory5",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D5.ToString())
                            ),
                        new XElement("KillCategory6",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D6.ToString())
                            ),
                        new XElement("KillCategory7",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D7.ToString())
                            ),
                        new XElement("KillCategory8",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D8.ToString())
                            ),
                        new XElement("KillCategory9",
                            new XElement("Modifier", (HotkeyConstants.CTRL + HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D9.ToString())
                            ),
                        new XElement("AddToCategory1",
                            new XElement("Modifier", (HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D1.ToString())
                            ),
                        new XElement("AddToCategory2",
                            new XElement("Modifier", (HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D2.ToString())
                            ),
                        new XElement("AddToCategory3",
                            new XElement("Modifier", (HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D3.ToString())
                            ),
                        new XElement("AddToCategory4",
                            new XElement("Modifier", (HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D4.ToString())
                            ),
                        new XElement("AddToCategory5",
                            new XElement("Modifier", (HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D5.ToString())
                            ),
                        new XElement("AddToCategory6",
                            new XElement("Modifier", (HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D6.ToString())
                            ),
                        new XElement("AddToCategory7",
                            new XElement("Modifier", (HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D7.ToString())
                            ),
                        new XElement("AddToCategory8",
                            new XElement("Modifier", (HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D8.ToString())
                            ),
                        new XElement("AddToCategory9",
                            new XElement("Modifier", (HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.D9.ToString())
                            ),
                        new XElement("AutodockToggle",
                            new XElement("Modifier", (HotkeyConstants.SHIFT + HotkeyConstants.CTRL).ToString()),
                            new XElement("Key", Keys.Tab.ToString())
                            ),
                        new XElement("DockUp",
                            new XElement("Modifier", (HotkeyConstants.NOMOD).ToString()),
                            new XElement("Key", Keys.Up.ToString())
                            ),
                        new XElement("DockDown",
                            new XElement("Modifier", (HotkeyConstants.NOMOD).ToString()),
                            new XElement("Key", Keys.Down.ToString())
                            ),
                        new XElement("DockLeft",
                            new XElement("Modifier", (HotkeyConstants.NOMOD).ToString()),
                            new XElement("Key", Keys.Left.ToString())
                            ),
                        new XElement("DockRight",
                            new XElement("Modifier", (HotkeyConstants.NOMOD).ToString()),
                            new XElement("Key", Keys.Right.ToString())
                            ),
                        new XElement("DockAlt",
                            new XElement("Modifier", (HotkeyConstants.ALT).ToString())
                            ),
                        new XElement("ShowAll",
                            new XElement("Modifier", (HotkeyConstants.WIN).ToString()),
                            new XElement("Key", Keys.G.ToString())
                            ),
                        new XElement("ShowCategory1",
                            new XElement("Modifier", (HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D1.ToString())
                            ),
                        new XElement("ShowCategory2",
                            new XElement("Modifier", (HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D2.ToString())
                            ),
                        new XElement("ShowCategory3",
                            new XElement("Modifier", (HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D3.ToString())
                            ),
                        new XElement("ShowCategory4",
                            new XElement("Modifier", (HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D4.ToString())
                            ),
                        new XElement("ShowCategory5",
                            new XElement("Modifier", (HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D5.ToString())
                            ),
                        new XElement("ShowCategory6",
                            new XElement("Modifier", (HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D6.ToString())
                            ),
                        new XElement("ShowCategory7",
                            new XElement("Modifier", (HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D7.ToString())
                            ),
                        new XElement("ShowCategory8",
                            new XElement("Modifier", (HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D8.ToString())
                            ),
                        new XElement("ShowCategory9",
                            new XElement("Modifier", (HotkeyConstants.ALT).ToString()),
                            new XElement("Key", Keys.D9.ToString())
                            ),
                        new XElement("HideAll",
                            new XElement("Modifier", (HotkeyConstants.WIN).ToString()),
                            new XElement("Key", Keys.H.ToString())
                            ),
                        new XElement("HideCategory1",
                            new XElement("Modifier", (HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D1.ToString())
                            ),
                        new XElement("HideCategory2",
                            new XElement("Modifier", (HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D2.ToString())
                            ),
                        new XElement("HideCategory3",
                            new XElement("Modifier", (HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D3.ToString())
                            ),
                        new XElement("HideCategory4",
                            new XElement("Modifier", (HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D4.ToString())
                            ),
                        new XElement("HideCategory5",
                            new XElement("Modifier", (HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D5.ToString())
                            ),
                        new XElement("HideCategory6",
                            new XElement("Modifier", (HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D6.ToString())
                            ),
                        new XElement("HideCategory7",
                            new XElement("Modifier", (HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D7.ToString())
                            ),
                        new XElement("HideCategory8",
                            new XElement("Modifier", (HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D8.ToString())
                            ),
                        new XElement("HideCategory9",
                            new XElement("Modifier", (HotkeyConstants.ALT + HotkeyConstants.SHIFT).ToString()),
                            new XElement("Key", Keys.D9.ToString())
                            ),
                        new XElement("Restore",
                            new XElement("Modifier", (HotkeyConstants.WIN).ToString()),
                            new XElement("Key", Keys.W.ToString())
                            ),
                        new XElement("SwapMainWindow",
                            new XElement("Modifier", (HotkeyConstants.WIN).ToString()),
                            new XElement("Key", Keys.S.ToString())
                            )
                ));
            hotkeyData.Save("hotkeys.xml");
        }

        public static void SaveData(string M_MU, string K_MU, string M_MD, string K_MD, string M_ML, string K_ML, string M_MR, string K_MR,
                                    string M_GW, string K_GW, string M_SW, string K_SW, string M_AAA, string K_AAA,
                                    string M_AC1, string K_AC1, string M_AC2, string K_AC2, string M_AC3, string K_AC3, string M_AC4, string K_AC4,
                                    string M_AC5, string K_AC5, string M_AC6, string K_AC6, string M_AC7, string K_AC7, string M_AC8, string K_AC8,
                                    string M_AC9, string K_AC9, string M_CAW, string K_CAW, string M_CC1, string K_CC1, string M_CC2, string K_CC2,
                                    string M_CC3, string K_CC3, string M_CC4, string K_CC4, string M_CC5, string K_CC5, string M_CC6, string K_CC6,
                                    string M_CC7, string K_CC7, string M_CC8, string K_CC8, string M_CC9, string K_CC9, string M_KAW, string K_KAW,
                                    string M_KC1, string K_KC1, string M_KC2, string K_KC2, string M_KC3, string K_KC3, string M_KC4, string K_KC4,
                                    string M_KC5, string K_KC5, string M_KC6, string K_KC6, string M_KC7, string K_KC7, string M_KC8, string K_KC8,
                                    string M_KC9, string K_KC9, string M_AtC1, string K_AtC1, string M_AtC2, string K_AtC2, string M_AtC3, string K_AtC3,
                                    string M_AtC4, string K_AtC4, string M_AtC5, string K_AtC5, string M_AtC6, string K_AtC6, string M_AtC7, string K_AtC7,
                                    string M_AtC8, string K_AtC8, string M_AtC9, string K_AtC9, string M_ADT, string K_ADT, string M_ADU, string K_ADU,
                                    string M_ADD, string K_ADD, string M_ADL, string K_ADL, string M_ADR, string K_ADR, string M_SDM, string M_SAW, string K_SAW,
                                    string M_SC1, string K_SC1, string M_SC2, string K_SC2, string M_SC3, string K_SC3, string M_SC4, string K_SC4,
                                    string M_SC5, string K_SC5, string M_SC6, string K_SC6, string M_SC7, string K_SC7, string M_SC8, string K_SC8,
                                    string M_SC9, string K_SC9, string M_HAW, string K_HAW, string M_HC1, string K_HC1, string M_HC2, string K_HC2,
                                    string M_HC3, string K_HC3, string M_HC4, string K_HC4, string M_HC5, string K_HC5, string M_HC6, string K_HC6,
                                    string M_HC7, string K_HC7, string M_HC8, string K_HC8, string M_HC9, string K_HC9, string M_R, string K_R, string M_SWM, string K_SWM)
        {
            XDocument hotkeyData = new XDocument(
                    new XDeclaration("1.0", "utf8", "yes"),
                    new XComment("Keybinds for Window Management Tool"),

                    new XElement("Hotkeys",
                        new XElement("MoveUp",
                            new XElement("Modifier", M_MU),
                            new XElement("Key", K_MU)
                            ),
                        new XElement("MoveDown",
                            new XElement("Modifier", M_MD),
                            new XElement("Key", K_MD)
                            ),
                        new XElement("MoveLeft",
                            new XElement("Modifier", M_ML),
                            new XElement("Key", K_ML)
                            ),
                        new XElement("MoveRight",
                            new XElement("Modifier", M_MR),
                            new XElement("Key", K_MR)
                            ),
                        new XElement("SizeUp",
                            new XElement("Modifier", M_GW),
                            new XElement("Key", K_GW)
                            ),
                        new XElement("SizeDown",
                            new XElement("Modifier", M_SW),
                            new XElement("Key", K_SW)
                            ),
                        new XElement("ArrangeAll",
                            new XElement("Modifier", M_AAA),
                            new XElement("Key", K_AAA)
                            ),
                        new XElement("ArrangeCategory1",
                            new XElement("Modifier", M_AC1),
                            new XElement("Key", K_AC1)
                            ),
                        new XElement("ArrangeCategory2",
                            new XElement("Modifier", M_AC2),
                            new XElement("Key", K_AC2)
                            ),
                        new XElement("ArrangeCategory3",
                            new XElement("Modifier", M_AC3),
                            new XElement("Key", K_AC3)
                            ),
                        new XElement("ArrangeCategory4",
                            new XElement("Modifier", M_AC4),
                            new XElement("Key", K_AC4)
                            ),
                        new XElement("ArrangeCategory5",
                            new XElement("Modifier", M_AC5),
                            new XElement("Key", K_AC5)
                            ),
                        new XElement("ArrangeCategory6",
                            new XElement("Modifier", M_AC6),
                            new XElement("Key", K_AC6)
                            ),
                        new XElement("ArrangeCategory7",
                            new XElement("Modifier", M_AC7),
                            new XElement("Key", K_AC7)
                            ),
                        new XElement("ArrangeCategory8",
                            new XElement("Modifier", M_AC8),
                            new XElement("Key", K_AC8)
                            ),
                        new XElement("ArrangeCategory9",
                            new XElement("Modifier", M_AC9),
                            new XElement("Key", K_AC9)
                            ),
                        new XElement("CloseAll",
                            new XElement("Modifier", M_CAW),
                            new XElement("Key", K_CAW)
                            ),
                        new XElement("CloseCategory1",
                            new XElement("Modifier", M_CC1),
                            new XElement("Key", K_CC1)
                            ),
                        new XElement("CloseCategory2",
                            new XElement("Modifier", M_CC2),
                            new XElement("Key", K_CC2)
                            ),
                        new XElement("CloseCategory3",
                            new XElement("Modifier", M_CC3),
                            new XElement("Key", K_CC3)
                            ),
                        new XElement("CloseCategory4",
                            new XElement("Modifier", M_CC4),
                            new XElement("Key", K_CC4)
                            ),
                        new XElement("CloseCategory5",
                            new XElement("Modifier", M_CC5),
                            new XElement("Key", K_CC5)
                            ),
                        new XElement("CloseCategory6",
                            new XElement("Modifier", M_CC6),
                            new XElement("Key", K_CC6)
                            ),
                        new XElement("CloseCategory7",
                            new XElement("Modifier", M_CC7),
                            new XElement("Key", K_CC7)
                            ),
                        new XElement("CloseCategory8",
                            new XElement("Modifier", M_CC8),
                            new XElement("Key", K_CC8)
                            ),
                        new XElement("CloseCategory9",
                            new XElement("Modifier", M_CC9),
                            new XElement("Key", K_CC9)
                            ),
                        new XElement("KillAll",
                            new XElement("Modifier", M_KAW),
                            new XElement("Key", K_KAW)
                            ),
                        new XElement("KillCategory1",
                            new XElement("Modifier", M_KC1),
                            new XElement("Key", K_KC1)
                            ),
                        new XElement("KillCategory2",
                            new XElement("Modifier", M_KC2),
                            new XElement("Key", K_KC2)
                            ),
                        new XElement("KillCategory3",
                            new XElement("Modifier", M_KC3),
                            new XElement("Key", K_KC3)
                            ),
                        new XElement("KillCategory4",
                            new XElement("Modifier", M_KC4),
                            new XElement("Key", K_KC4)
                            ),
                        new XElement("KillCategory5",
                            new XElement("Modifier", M_KC5),
                            new XElement("Key", K_KC5)
                            ),
                        new XElement("KillCategory6",
                            new XElement("Modifier", M_KC6),
                            new XElement("Key", K_KC6)
                            ),
                        new XElement("KillCategory7",
                            new XElement("Modifier", M_KC7),
                            new XElement("Key", K_KC7)
                            ),
                        new XElement("KillCategory8",
                            new XElement("Modifier", M_KC8),
                            new XElement("Key", K_KC8)
                            ),
                        new XElement("KillCategory9",
                            new XElement("Modifier", M_KC9),
                            new XElement("Key", K_KC9)
                            ),
                        new XElement("AddToCategory1",
                            new XElement("Modifier", M_AtC1),
                            new XElement("Key", K_AtC1)
                            ),
                        new XElement("AddToCategory2",
                            new XElement("Modifier", M_AtC2),
                            new XElement("Key", K_AtC2)
                            ),
                        new XElement("AddToCategory3",
                            new XElement("Modifier", M_AtC3),
                            new XElement("Key", K_AtC3)
                            ),
                        new XElement("AddToCategory4",
                            new XElement("Modifier", M_AtC4),
                            new XElement("Key", K_AtC4)
                            ),
                        new XElement("AddToCategory5",
                            new XElement("Modifier", M_AtC5),
                            new XElement("Key", K_AtC5)
                            ),
                        new XElement("AddToCategory6",
                            new XElement("Modifier", M_AtC6),
                            new XElement("Key", K_AtC6)
                            ),
                        new XElement("AddToCategory7",
                            new XElement("Modifier", M_AtC7),
                            new XElement("Key", K_AtC7)
                            ),
                        new XElement("AddToCategory8",
                            new XElement("Modifier", M_AtC8),
                            new XElement("Key", K_AtC8)
                            ),
                        new XElement("AddToCategory9",
                            new XElement("Modifier", M_AtC9),
                            new XElement("Key", K_AtC9)
                            ),
                        new XElement("AutodockToggle",
                            new XElement("Modifier", M_ADT),
                            new XElement("Key", K_ADT)
                            ),
                        new XElement("DockUp",
                            new XElement("Modifier", M_ADU),
                            new XElement("Key", K_ADU)
                            ),
                        new XElement("DockDown",
                            new XElement("Modifier", M_ADD),
                            new XElement("Key", K_ADD)
                            ),
                        new XElement("DockLeft",
                            new XElement("Modifier", M_ADL),
                            new XElement("Key", K_ADL)
                            ),
                        new XElement("DockRight",
                            new XElement("Modifier", M_ADR),
                            new XElement("Key", K_ADR)
                            ),
                        new XElement("DockAlt",
                            new XElement("Modifier", M_SDM)
                            ),
                        new XElement("ShowAll",
                            new XElement("Modifier", M_SAW),
                            new XElement("Key", K_SAW)
                            ),
                        new XElement("ShowCategory1",
                            new XElement("Modifier", M_SC1),
                            new XElement("Key", K_SC1)
                            ),
                        new XElement("ShowCategory2",
                            new XElement("Modifier", M_SC2),
                            new XElement("Key", K_SC2)
                            ),
                        new XElement("ShowCategory3",
                            new XElement("Modifier", M_SC3),
                            new XElement("Key", K_SC3)
                            ),
                        new XElement("ShowCategory4",
                            new XElement("Modifier", M_SC4),
                            new XElement("Key", K_SC4)
                            ),
                        new XElement("ShowCategory5",
                            new XElement("Modifier", M_SC5),
                            new XElement("Key", K_SC5)
                            ),
                        new XElement("ShowCategory6",
                            new XElement("Modifier", M_SC6),
                            new XElement("Key", K_SC6)
                            ),
                        new XElement("ShowCategory7",
                            new XElement("Modifier", M_SC7),
                            new XElement("Key", K_SC7)
                            ),
                        new XElement("ShowCategory8",
                            new XElement("Modifier", M_SC8),
                            new XElement("Key", K_SC8)
                            ),
                        new XElement("ShowCategory9",
                            new XElement("Modifier", M_SC9),
                            new XElement("Key", K_SC9)
                            ),
                        new XElement("HideAll",
                            new XElement("Modifier", M_HAW),
                            new XElement("Key", K_HAW)
                            ),
                        new XElement("HideCategory1",
                            new XElement("Modifier", M_HC1),
                            new XElement("Key", K_HC1)
                            ),
                        new XElement("HideCategory2",
                            new XElement("Modifier", M_HC2),
                            new XElement("Key", K_HC2)
                            ),
                        new XElement("HideCategory3",
                            new XElement("Modifier", M_HC3),
                            new XElement("Key", K_HC3)
                            ),
                        new XElement("HideCategory4",
                            new XElement("Modifier", M_HC4),
                            new XElement("Key", K_HC4)
                            ),
                        new XElement("HideCategory5",
                            new XElement("Modifier", M_HC5),
                            new XElement("Key", K_HC5)
                            ),
                        new XElement("HideCategory6",
                            new XElement("Modifier", M_HC6),
                            new XElement("Key", K_HC6)
                            ),
                        new XElement("HideCategory7",
                            new XElement("Modifier", M_HC7),
                            new XElement("Key", K_HC7)
                            ),
                        new XElement("HideCategory8",
                            new XElement("Modifier", M_HC8),
                            new XElement("Key", K_HC8)
                            ),
                        new XElement("HideCategory9",
                            new XElement("Modifier", M_HC9),
                            new XElement("Key", K_HC9)
                            ),
                        new XElement("Restore",
                            new XElement("Modifier", M_R),
                            new XElement("Key", K_R)
                            ),
                        new XElement("SwapMainWindow",
                            new XElement("Modifier", M_SWM),
                            new XElement("Key", K_SWM)
                            )
                ));
            hotkeyData.Save("hotkeys.xml");
        }
        
        public Keys GetKey(string element)
        {
            var query = Document.Descendants(element).Select(s => new
            {
                Key = s.Element("Key").Value
            }).FirstOrDefault();
            string keyString = query.Key;
            return (Keys)Enum.Parse(typeof(Keys), keyString);
        }

        public int GetMod(string element)
        {
            var query = Document.Descendants(element).Select(s => new
            {
                Modifier = s.Element("Modifier").Value
            }).FirstOrDefault();
            string modString = query.Modifier;

            return int.Parse(modString);
        }
    }
}
