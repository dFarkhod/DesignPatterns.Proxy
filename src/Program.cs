Console.WriteLine("subject'ni to'g'ridan-to'g'ri chaqiramiz:");
RealSubject realSubject = new();
realSubject.Request();

Console.WriteLine();

Console.WriteLine("subject'ni proxy orqali chaqiramiz:");
Proxy proxy = new();
proxy.Request();


public interface ISubject
{
    void Request();
}

class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: so'rovni qabul qilib oldim...");
        // ...
    }
}

class Proxy : ISubject
{
    private readonly RealSubject _realSubject;

    public Proxy()
    {
        _realSubject = new();
    }

    public void Request()
    {
        // bu yerda so'rovni haqiqiy subject'ga jo'natishdan oldin
        // foydalanuvchining xuquqini tekshirish, caching, logging
        // kabi ishlarni bajarishimiz mumkin.
        if (AccessGranted())
        {
            _realSubject.Request();
            LogAccess();
        }
    }

    private bool AccessGranted()
    {
        Console.WriteLine("Proxy: foydalanuvchining xuquqlari tekshirilyapti...");
        return true;
    }

    private void LogAccess()
    {
        Console.WriteLine("Proxy: So'rovni log'ga yozamiz.");
    }
}



