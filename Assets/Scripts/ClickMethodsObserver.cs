using System.Collections.ObjectModel;

public sealed class ClickMethodsObserver
{
    private static ClickMethodsObserver current = null;
    private static readonly object padlock = new object();
    private static ObservableCollection<string> methods = null;
  
    public ObservableCollection<string> Methods
    {
        get
        {
            if (methods == null)
            {
                methods = new ObservableCollection<string>();
            }
            return methods;
        }
    }

    ClickMethodsObserver()
    {

    }
    public static ClickMethodsObserver Current
    {
        get
        {
            lock (padlock)
            {
                if (current == null)
                {
                    current = new ClickMethodsObserver();
                }
                return current;
            }
        }
    }

    public void AddMethodToSecure(string methodname)
    {
        if(CheckIsMethodSecured(methodname))
        {
            Methods.Add(methodname);
        }        
    }

    public void RemoveMethodToSecure(string methodname)
    {
        Methods.Remove(methodname);
    }

    private bool CheckIsMethodSecured(string methodname)
    {
        string startRoutine = "StartGame2";
        //Check gegen SAPL-Server
        if (methodname.Contains(startRoutine))
        {
            //Check schlägt fehl, Routine kommt nicht in die Liste
            return false;
        }
        return true;
    }
}
