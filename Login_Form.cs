﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sistema_gestao_estudantes
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            // Define a imagem da picture box via código.
            pictureBox1.Image = Image.FromFile("../../imagens/brunodiferente.gif");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            MEU_BD bancoDeDados =  new MEU_BD();

            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            DataTable tabela = new DataTable(); ;
            MySqlCommand comando = new MySqlCommand("SELECT * FROM `usuario` WHERE `username` = @usn and `password` = @psd ", bancoDeDados.getConexao);

            comando.Parameters.Add("@usn", MySqlDbType.VarChar).Value = txtUsuario.Text;
            comando.Parameters.Add("@psd", MySqlDbType.VarChar).Value = txtSenha.Text;

            adaptador.SelectCommand = comando;
            adaptador.Fill(tabela);

            if(tabela.Rows.Count > 0)
            {
                MessageBox.Show("SIM");
            }
            else
            {
                MessageBox.Show("Nome de Usuário ou Senha Inválido","Erro de Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
