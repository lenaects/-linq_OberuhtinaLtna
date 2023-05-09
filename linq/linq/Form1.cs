using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace linq
{
    public partial class Form1 : Form
    {
        private List<Zad1> zadan1;
        List<Department> department = new List<Department>();
        private List<Employ> employes = new List<Employ>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            zadan1 = new List<Zad1>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Zad1> youngpeople = new List<Zad1>();
            youngpeople.Clear();
            listBox1.Items.Clear();
            youngpeople = zadan1.Where(zadan1 => zadan1.Age < 40).ToList();
            foreach (Zad1 person in youngpeople)
            {
                listBox1.Items.Add(person);
            }

        }

   

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Visible=false;
            button4.Visible=false;
            listBox1.Visible = true;
            button1.Visible=true;
            string file = "zad1.txt";
            listBox1.Items.Clear();
            zadan1.Clear();
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    string[] cole = line.Split(' ');
                    string F = cole[0];
                    string I = cole[1];
                    string O = cole[2];
                    int age = int.Parse(cole[3]);
                    int ves = int.Parse(cole[4]);
                    Zad1 person = new Zad1(F, I, O, age, ves);
                    zadan1.Add(person);
                    listBox1.Items.Add(line);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Visible = true;
            button4.Visible = true;
            listBox1.Visible = false;
            button1.Visible = false;
            listBox2.Items.Clear();
            department.Clear();
            employes.Clear();
            department.Add(new Department() { Name = "Отдел закупок", Reg = "Германия" });
            department.Add(new Department() { Name = "Отдел продаж", Reg = "Испания" });
            department.Add(new Department() { Name = "Отдел маркетинга", Reg = "Иран" });
            employes.Add(new Employ() { Name = "Иванов", Department = "Отдел закупок" });
            employes.Add(new Employ() { Name = "Петров", Department = "Отдел закупок" });
            employes.Add(new Employ() { Name = "Сидоров", Department = "Отдел продаж" });
            employes.Add(new Employ() { Name = "Лямин", Department = "Отдел продаж" });
            employes.Add(new Employ() { Name = "Сидоренко", Department = "Отдел маркетинга" });
            employes.Add(new Employ() { Name = "Кривоносов", Department = "Отдел продаж" });
            var query = from emp in employes
                        join dep in department on emp.Department equals dep.Name
                        group emp by dep into depGroup
                        select new
                        {
                            Department = depGroup.Key.Name,
                            Employees = depGroup.Select(emp => emp.Name)
                        };

            foreach (var group in query)
            {
                listBox2.Items.Add(group.Department);
                foreach (var emp in group.Employees)
                {
                    listBox2.Items.Add("   " + emp);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            listBox2.Items.Clear();
            var result = from employ in employes
                         join dep in department on employ.Department equals dep.Name
                         where dep.Reg.StartsWith("И")
                         select new { employ.Name, dep.Reg };

            foreach (var item in result)
            {
                listBox2.Items.Add(item.Name + " - " + item.Reg);
            }
        }
    }
}
  