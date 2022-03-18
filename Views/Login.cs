using System;
using Forms.Lib;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Views
{
    public class Login : BaseForm
    {
        private System.ComponentModel.IContainer components = null;

        Field fieldUser;
        Field fieldPass;

        Button btnConfirm;
        Button btnCancel;

        public Login() : base("Login")
        {
            this.fieldUser = new Field(this.Controls, "Username", 20, true);
            this.fieldPass = new Field(this.Controls, "Password", 80, true, true);
            this.fieldPass.textField.ForeColor = System.Drawing.Color.Red;
            this.btnConfirm = new ButtonForm(this.Controls, "Confirm", 100, 180, this.handleConfirmClick);
            this.btnCancel = new ButtonForm(this.Controls, "Cancel", 100, 220, this.handleCancelClick);
            
            this.components = new System.ComponentModel.Container();
        }

        private void handleConfirmClick(object sender, EventArgs e) 
        {
            DialogResult result;

            result = MessageBox.Show(
                $"Usuário: {this.fieldUser.textField.Text}" +
                $"\nSenha: {this.fieldPass.textField.Text}",
                "Titulo da Mensagem",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                Form2 menu = new Form2();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                Console.WriteLine("Clicou não");
            }
        }
        
        private void handleCancelClick(object sender, EventArgs e) 
        {
            this.Close();
        }

    }
}