using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RizRiver.Linq.LinqCondition;

namespace Sample
{
    public partial class SampleFinderForm : Form
    {
        public SampleFinderForm()
        {
            InitializeComponent();
        }

        private Person[] _dataStore;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            #region setup test data
            Random random = new Random();
            List<Person> personList = new List<Person>();
            for (int i = 0; i < 1000; i++)
            {
                Person person = new Person();
                person.ID = i;
                person.Name = "Person" + i.ToString("0000");
                person.Age = random.Next(100);
                person.IsMale = random.Next(2) == 0;
                person.BloodType = new[] { "A", "B", "O", "AB" }[random.Next(4)];
                personList.Add(person);
            }
            _dataStore = personList.ToArray();
            #endregion

            this.InitSearchCondition();
        }

        private void InitSearchCondition()
        {
            this.txtName.Text = string.Empty;
            this.rdbExactMatch.Checked = true;
            this.txtAgeFrom.Text = "0";
            this.txtAgeTo.Text = "99";
            this.rdbGenderBoth.Checked = true;
            this.lstBloodType.SelectedIndex = -1;
            this.txtExpression.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ConditionChain conditionChain = ConditionChain.Empty;

            if (txtName.Text != string.Empty)
            {
                Condition condition;
                if (rdbExactMatch.Checked)
                {
                    condition = Condition.Create("Name", txtName.Text);
                }
                else
                {
                    condition = Condition.Create("Name", txtName.Text, LikeTypes.Part);
                }
                conditionChain.AndAlso(condition);
            }

            if (!this.rdbGenderBoth.Checked)
            {
                conditionChain.AndAlso(Condition.Create("IsMale", this.rdbGenderMale.Checked));
            }

            if (txtAgeFrom.Text != string.Empty)
            {
                conditionChain.AndAlso(Condition.Create("Age", int.Parse(txtAgeFrom.Text), CompareType.GreaterThanOrEqual));
            }

            if (txtAgeTo.Text != string.Empty)
            {
                conditionChain.AndAlso(Condition.Create("Age", int.Parse(txtAgeTo.Text), CompareType.LessThanOrEqual));
            }

            if (lstBloodType.SelectedItems.Count != 0)
            {
                ConditionChain bloodTypeCondChain = ConditionChain.Empty;
                foreach (string bloodType in lstBloodType.SelectedItems)
                {
                    bloodTypeCondChain.OrElse(Condition.Create("BloodType", bloodType));
                }
                conditionChain.AndAlso(bloodTypeCondChain);
            }

            // debug info.
            this.txtExpression.Text = conditionChain.IsEmpty ? "" : conditionChain.GetExpression<Person>().ToString();

            Person[] searchResult = this.SearchByCondition(conditionChain);
            this.dataGridView1.DataSource = searchResult;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.InitSearchCondition();
        }

        private Person[] SearchByCondition(ConditionChain conditionChain)
        {
            return _dataStore.Where(conditionChain).ToArray();
        }

    }
}
