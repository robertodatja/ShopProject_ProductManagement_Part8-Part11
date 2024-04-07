using System.Windows.Forms;
namespace Part11
{
    public static class FolderBrowserManager
    {
        public static string SelectFolderLocation()
        {
            var dialogBox = new FolderBrowserDialog();
            var result = dialogBox.ShowDialog();
            switch(result)
            {
                //Nqs rezultati qe ne na vjen eshte OK dmth qe kemi zgjedhur nje folder.
                case DialogResult.OK: 
                    if (string.IsNullOrEmpty(dialogBox.SelectedPath))
                    {
                        throw new Exception("Please select a valid location.");
                    }
                    return dialogBox.SelectedPath;
                    //break;
                default:
                    throw new Exception("Unknown Operation.");
            }
        }
    }
}
