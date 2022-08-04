﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;


namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        

        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
                                                
        public CreateTeamForm()
        {
            InitializeComponent();

            // Kept sample data for testing purposes
            //CreateSampleData();

            WireUpLists();
        }

        

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Eoghan", LastName = "Butler" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Mary", LastName = "Moran" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Steven", LastName = "Laird" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "David", LastName = "Zerbe" });
        }


        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }   

        private void CreateTeamForm_Load(object sender, EventArgs e)
        {

        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.PhoneNumber = phoneValue.Text;

                foreach (IDataConnection db in GlobalConfig.Connection)
                {
                    db.CreatePerson(p);
                }



                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                phoneValue.Text = "";

            }
            else
            {
                MessageBox.Show("All feilds must be completed.");
            }
        }

        private bool ValidateForm()
        {
            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }

            if (emailValue.Text.Length == 0)
            {
                return false;
            }

            if (phoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
