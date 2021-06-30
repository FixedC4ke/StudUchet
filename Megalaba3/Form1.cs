using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Megalaba3
{
    public partial class Form1 : Form
    {
        private DBEntities db = new DBEntities();
        private Guid UserID;
        private bool Role;
        public Form1(Guid userid, bool role)
        {
            UserID = userid;
            Role = role;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMenu();
        }


        private void LoadMenu()
        {
            using (DBEntities db = new DBEntities())
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add("Задания");
                treeView1.Nodes.Add("Ведомость");
                treeView1.Nodes.Add("Запросы");


                var discs = db.Discipline;
                var groups = (IQueryable<Groups>) db.Groups;

                if (!Role)
                {
                    Users currentUser = db.Users.Find(UserID);
                    groups = db.Groups.Where(x=>x.ID==currentUser.GroupID);
                }
                

                for (int i = 0; i < treeView1.Nodes.Count; i++)
                {
                    foreach (Groups g in groups)
                    {
                        TreeNode tr = treeView1.Nodes[i].Nodes.Add(g.Name);
                        foreach (Discipline d in discs) tr.Nodes.Add(d.Name);
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string[] path = e.Node.FullPath.Split('\\');
            if (path.Length < 3) return;
            if (path[0] == "Ведомость")
            {
                var data = (from grade in db.Grades.ToList()
                           join user in db.Users
                           on grade.StudentID equals user.ID
                           join disc in db.Discipline
                           on grade.DisciplineID equals disc.ID
                           join grp in db.Groups
                           on user.GroupID equals grp.ID
                           where disc.Name == path[2] && grp.Name==path[1]
                           select new
                           {
                               ФИО=user.Fullname,
                               Баллы=grade.Grade
                           }).ToList();
                dataGridView1.DataSource = data;
            }
            else if (path[0] == "Задания")
            {
                var data = (from act in db.Activities.ToList()
                            join disc in db.Discipline
                            on act.DisciplineID equals disc.ID
                            join user in db.Users
                            on act.StudentID equals user.ID
                            into acts
                            from a in acts.DefaultIfEmpty(new Users())
                            where disc.Name == path[2]
                            select new
                            {
                                Название = act.Name,
                                Описание = act.Description,
                                Занял = a.Fullname,
                                Баллы = act.Cost,
                                Выполнено=act.Done
                            }).ToList();
                dataGridView1.DataSource = data;
            }
            else if (path[0] == "Запросы")
            {
                var data = (from req in db.Requests.ToList()
                            join disc in db.Discipline
                            on req.DisciplineID equals disc.ID
                            join user in db.Users
                            on req.UserID equals user.ID
                            join act in db.Activities
                            on req.ActivityID equals act.ID
                            join grp in db.Groups
                            on user.GroupID equals grp.ID
                            where disc.Name == path[2] && grp.Name == path[1]
                            select new
                            {
                                Студент = user.Fullname,
                                Задание = act.Name
                            }).ToList();
                dataGridView1.DataSource = data;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }
    }
}
