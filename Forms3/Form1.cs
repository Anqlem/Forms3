using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Forms3
{
    public partial class Form1 : Form
    {

        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton rb1, rb2;
        TextBox txt_box;

        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            //Button
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += Btn_Click;
            //Label
            tn.Nodes.Add(new TreeNode("Label"));
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);

            tn.Nodes.Add(new TreeNode("CheckBox"));
            tn.Nodes.Add(new TreeNode("Radiobutton"));
            tn.Nodes.Add(new TreeNode("TextKast"));
          


            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Label")
            {
                lbl = new Label();
                lbl.Text = "Tarkvara arendajad";
                lbl.Size = new Size(150, 30);
                lbl.Location = new Point(150, 200);
                this.Controls.Add(lbl);
            }

            else if (e.Node.Text == "CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Naita button";
                box_btn.Location = new Point(200, 30);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Naita label";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;
            }
            else if (e.Node.Text == "Radiobutton")
            {
                rb1 = new RadioButton();
                rb1.Text = "Vasakule-Button";
                rb1.Location = new Point(320, 30);
                rb1.CheckedChanged += new EventHandler(RadioButtons_Changed);
                rb2 = new RadioButton();
                rb2.Text = "Paremale-Button";
                rb2.Location = new Point(320, 70);
                rb2.CheckedChanged += new EventHandler(RadioButtons_Changed);

                this.Controls.Add(rb1);
                this.Controls.Add(rb2);
            }

            else if (e.Node.Text == "TextKast")
            {
                string text;
                try
                {
                    text = File.ReadAllText("text.txt");
                }
                catch (FileNotFoundException excpetion)
                {
                    text = "Tekst Puudub";
                }
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = text;
                txt_box.Location = new Point(300, 300);
                txt_box.Width = 200;
                txt_box.Height = 200;
                this.Controls.Add(txt_box);
            }
        }

        private void RadioButtons_Changed(object sender, EventArgs e)
        {
            if (rb1.Checked)
            {
                btn.Location = new Point(150, 100);
            }
            else if (rb2.Checked)
            {
                btn.Location = new Point(400, 100);
            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                this.Controls.Add(lbl);
            }
            else
            {
                this.Controls.Remove(lbl);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                this.Controls.Add(btn);
            }
            else
            {
                this.Controls.Remove(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Blue;
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Green;
            }
        }
    }
}