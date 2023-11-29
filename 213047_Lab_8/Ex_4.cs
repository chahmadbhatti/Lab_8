private void button1_Click(object sender, EventArgs e)
{
    try
    {
    string connstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data
    Source=C:\Users\Taimur Sattar\Documents\DB_test.accdb; Persist Security Info = False";
    OleDbConnection conn = new OleDbConnection(connstr);
    conn.Open();
    MessageBox.Show("Connection successfull..");
    string qry = "Select * from Student";
    OleDbCommand cmd = new OleDbCommand(qry, conn);
    OleDbDataReader dr = cmd.ExecuteReader();
    while(dr.Read())
    {
    MessageBox.Show(dr["Roll_no"].ToString());
    }
    }
    catch(Exception ex)
    {
    MessageBox.Show(ex.Message);
    }
}