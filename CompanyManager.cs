using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlink_WAP_Project
{
    class CompanyManager
    {
        private static int currentCompNumber;
        private int maxNumCompanies;
        private int numCompanies;
        private Company[] companyList;

        //constructor
        public CompanyManager(int ccn, int max)
        {
            currentCompNumber = ccn;
            maxNumCompanies = max;
            numCompanies = 0;
            companyList = new Company[maxNumCompanies];
        }

        //add company to company list
        public bool addCompany(string nm, string loc, string ph)
        {
            if (numCompanies >= maxNumCompanies) { return false; }
            Company c = new Company(currentCompNumber, nm, loc, ph);
            currentCompNumber++;
            companyList[numCompanies] = c;
            numCompanies++;
            return true;
        }

        public int findCompany(int cid)
        {
            for (int x = 0; x < numCompanies; x++)
            {
                if (companyList[x].getId() == cid)
                    return x;
            }
            return -1;
        }

        public bool companyExist(int cid)
        {
            int loc = findCompany(cid);
            if (loc == -1) { return false; }
            return true;
        }

        public Company getCompany(int cid)
        {
            int loc = findCompany(cid);
            if (loc == -1) { return null; }
            return companyList[loc];
        }

        public bool deleteCompany(int cid)
        {
            int loc = findCompany(cid);
            if (loc == -1) { return false; }
            companyList[loc] = companyList[numCompanies - 1];
            numCompanies--;
            return true;
        }

        public int getMaxCompanies()
        {
            return maxNumCompanies;
        }

        //print company list one by one row (in purposes to use dataGridView in Forms)
        public string getCompanyList(int cid)
        {
            string s = "";
            s += " id: ";
            s += companyList[findCompany(cid)].getId() + " , name: " + companyList[findCompany(cid)].getName() + " " + companyList[findCompany(cid)].getLocation() + " , phone: " + companyList[findCompany(cid)].getPhone();
            return s;
        }
    }
}
