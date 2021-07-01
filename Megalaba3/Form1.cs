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
using System.Security.Cryptography;

namespace Megalaba3
{
    public partial class Form1 : Form
    {
        private DBEntities db = new DBEntities();
        private Guid UserID;
        private bool Role;
        private string Fullname;
        private string[] currentpath;
        public Form1(Guid userid, bool role, string fullname)
        {
            UserID = userid;
            Role = role;
            Fullname = fullname;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adduserToolStripMenuItem.Visible = addGroupToolStripMenuItem.Visible = addDiscToolStripMenuItem.Visible = Role;
            toolStripStatusLabel1.Text = "Вы вошли как: " + Fullname + " | " + (Role ? "преподаватель" : "студент");
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


                var discs = (IQueryable<Discipline>)db.Discipline;
                var groups = (IQueryable<Groups>)db.Groups;
                Users currentUser = db.Users.Find(UserID);
                if (!Role)
                {
                    groups = db.Groups.Where(x => x.ID == currentUser.GroupID);
                }
                else
                {
                    discs = db.Discipline.Where(x => x.TeacherID == currentUser.ID);
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
                            where disc.Name == path[2] && grp.Name == path[1]
                            select new
                            {
                                ФИО = user.Fullname,
                                Баллы = grade.Grade
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
                                Выполнено = act.Done
                            }).ToList();
                dataGridView1.DataSource = data;
                if (Role)
                {
                    dataGridView1.ContextMenuStrip = teacherActMenu;
                    currentpath = path;
                }
                else
                {
                    dataGridView1.ContextMenuStrip = studActMenu;
                }
            }
            else if (path[0] == "Запросы")
            {
                var data = (from req in db.Requests.ToList()
                            join disc in db.Discipline
                            on req.DisciplineID equals disc.ID
                            join user in db.Users
                            on req.UserID equals user.ID
                            join grp in db.Groups
                            on user.GroupID equals grp.ID
                            where disc.Name == path[2] && grp.Name == path[1]
                            select new
                            {
                                Студент = user.Fullname,
                                Задание = req.ActivityName,
                                Баллы = req.ActivityCost
                            }).ToList();
                dataGridView1.DataSource = data;
                if (Role)
                {
                    dataGridView1.ContextMenuStrip = teacherReqMenu;
                }
                else
                {
                    dataGridView1.ContextMenuStrip = studReqMenu;
                }
                currentpath = path;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void addActivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddActivity addActivity = new AddActivity();
            if (addActivity.ShowDialog() == DialogResult.OK)
            {
                string discname = currentpath[2];
                var disc = db.Discipline.Where(x => x.Name == discname).First();
                db.Activities.Add(new Activities() { ID = Guid.NewGuid(), Name = addActivity.ActName, Description = addActivity.Description, Cost = addActivity.Cost, DisciplineID = disc.ID, StudentID = null });
                db.SaveChanges();
            }
        }

        private void removeActivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string desc = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            var act = db.Activities.Single(x => x.Name == name && x.Description == desc);
            db.Activities.Remove(act);
            db.SaveChanges();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            teacherActMenu.Items[1].Enabled = studActMenu.Items[0].Enabled = teacherReqMenu.Items[0].Enabled = teacherReqMenu.Items[1].Enabled = dataGridView1.SelectedRows.Count == 1;
        }

        private void studTakeActToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string desc = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            var act = db.Activities.Single(x => x.Name == name && x.Description == desc);
            if (!act.StudentID.HasValue)
            {
                act.StudentID = UserID;
                db.SaveChanges();
            }
            else MessageBox.Show("Данное задание уже занято!");
        }

        private void acceptDoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string desc = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            var act = db.Activities.Single(x => x.Name == name && x.Description == desc);
            if (!act.Done)
            {
                act.Done = true;
                var stud = db.Users.Single(x => x.ID == act.StudentID);
                var grades = db.Grades.SingleOrDefault(x => x.StudentID == stud.ID);
                if (grades == null)
                {
                    string discname = currentpath[2];
                    var disc = db.Discipline.Single(x => x.Name == discname);
                    grades = db.Grades.Add(new Grades() { ID = Guid.NewGuid(), StudentID = stud.ID, DisciplineID = disc.ID, Grade = 0 });
                }
                grades.Grade = (int)grades.Grade + (int)act.Cost;
                db.SaveChanges();
            }
        }

        private void studDropActToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string desc = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            var act = db.Activities.Single(x => x.Name == name && x.Description == desc);
            if (act.StudentID == UserID)
            {
                if (act.Done)
                {
                    MessageBox.Show("Данное задание уже засчитано");
                    return;
                }
                act.StudentID = null;
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Задание занято не Вами");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void studReqSendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRequest req = new AddRequest();
            if (req.ShowDialog() == DialogResult.OK)
            {
                string discname = currentpath[2];
                var disc = db.Discipline.Single(x => x.Name == discname);
                db.Requests.Add(new Requests() { ID = Guid.NewGuid(), UserID = UserID, ActivityName = req.ActivityName, ActivityCost = req.ActivityCost, DisciplineID = disc.ID });
                db.SaveChanges();
            }
        }

        private void acceptReqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int grade = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
            var req = db.Requests.Single(x => x.ActivityName == name && x.ActivityCost == grade);
            var grades = db.Grades.SingleOrDefault(x => x.StudentID == req.UserID);
            if (grades == null)
            {
                string discname = currentpath[2];
                var disc = db.Discipline.Single(x => x.Name == discname);
                grades = db.Grades.Add(new Grades() { ID = Guid.NewGuid(), StudentID = req.UserID, DisciplineID = disc.ID, Grade=0});
            }
            grades.Grade = (int)grades.Grade + (int)req.ActivityCost;
            db.Requests.Remove(req);
            db.SaveChanges();
        }

        private void declineReqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int grade = (int)dataGridView1.SelectedRows[1].Cells[2].Value;
            var req = db.Requests.Single(x => x.ActivityName == name && x.ActivityCost == grade);
            db.Requests.Remove(req);
            db.SaveChanges();
        }

        private void adduserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser au = new AddUser();
            if (au.ShowDialog() == DialogResult.OK)
            {
                if (db.Users.Where(x => x.Username == au.Username).Count() > 0)
                {
                    MessageBox.Show("Пользователь с таким именем уже существует");
                }
                else
                {
                    SHA256 hashfunc = SHA256.Create();
                    Guid id = Guid.NewGuid();
                    string salt = id.ToString();
                    string password = Convert.ToBase64String(hashfunc.ComputeHash(Encoding.UTF8.GetBytes(salt + au.Password)));
                    if (au.Role)
                    {
                        db.Users.Add(new Users() { ID = id, Username = au.Username, Password = password, Role = au.Role, GroupID = null, Fullname = au.Fullname });
                        var disc = db.Discipline.Single(x => x.ID == au.GroupOrDisc);
                        disc.TeacherID = id;
                        db.SaveChanges();

                    }
                    else
                    {
                        db.Users.Add(new Users() { ID = id, Username = au.Username, Password = password, Role = au.Role, GroupID = au.GroupOrDisc, Fullname = au.Fullname });
                        db.SaveChanges();

                    }
                }
            }
        }

        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleAdd sa = new SimpleAdd("группы");
            if (sa.ShowDialog() == DialogResult.OK)
            {
                db.Groups.Add(new Groups() { ID = Guid.NewGuid(), Name = sa.Value });
                db.SaveChanges();
            }
        }

        private void addDiscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleAdd sa = new SimpleAdd("предмета");
            if (sa.ShowDialog() == DialogResult.OK)
            {
                db.Discipline.Add(new Discipline() { ID = Guid.NewGuid(), Name = sa.Value, TeacherID = UserID });
                db.SaveChanges();
            }
        }
    }
}
