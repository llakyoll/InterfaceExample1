using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            string mark = new string('-', 6);
            int value;
            DatabaseManager database;
            Console.WriteLine("{0}\n< C# Interface Örnekleri >\n{1}", mark, mark);
            Console.WriteLine("[1] - Oracle Database Bağlantısı Kur\n[2] - Mysql Database Bağlantısı Kur\n{0}", mark);
            Console.Write("-> Kararınız: ");
            value = Convert.ToInt32(Console.ReadLine());
            switch (value)
            {
                case 1:
                    database = new DatabaseManager(new OracleDatabaseManager());
                    database.loginDB();
                    break;
                case 2:
                    database = new DatabaseManager(new MySqlDatabaseManager());
                    database.loginDB();
                    break;
                default:
                    Console.WriteLine(mark);
                    break;
            }
            Console.ReadLine();
        }
        interface IDatabase
        {
            void Add(string value);
            void Delete();
            void Get();
            void Close();
            int login(string username, string password);
        }
        class MySqlDatabaseManager : IDatabase
        {
            private string value, username = "mysql", password = "admin", mark = new string('-', 6);
            public void Add(string value)
            {
                this.value = value;
            }

            public void Close()
            {
                Console.WriteLine("{0}\n-> Mysql veritabanı bağlantınız başarılı bir şekilde sonlandırıldı.\n{1}", mark, mark);
            }

            public void Delete()
            {
                this.value = null;
                Console.WriteLine("{0}\n-> Veri tabanı üzerinde tutmuş olduğum verileri başarılı bir şekilde sildim.\n{1}", mark, mark);
            }

            public void Get()
            {
                if (value != null)
                {
                    Console.WriteLine("{0}\n-> İsteğiniz doğrultuda hafızamdaki [{1}] verisini başarılı bir şekilde getirdim.\n{2}", mark, value, mark);
                }
                else
                {
                    Console.WriteLine("{0}\n-> Veri tabanı içerisinde henüz bir veri bulunmuyor. Lütfen daha sonra tekrar deneyin.\n{1}", mark, mark);
                }
            }

            public int login(string username, string password)
            {
                if (username == this.username && password == this.password)
                    return 1;
                else
                    return 0;
            }
        }
        class OracleDatabaseManager : IDatabase
        {
            private string value, username = "oracle", password = "database", mark = new string('-', 6);
            public void Add(string value)
            {
                this.value = value;
            }

            public void Close()
            {
                Console.WriteLine("{0}\n-> Oracle veritabanı bağlantınız başarılı bir şekilde sonlandırıldı.\n{1}", mark, mark);
            }

            public void Delete()
            {
                this.value = null;
                Console.WriteLine("{0}\n-> Veri tabanı üzerinde tutmuş olduğum verileri başarılı bir şekilde sildim.\n{1}", mark, mark);
            }

            public void Get()
            {
                if (value != null)
                {
                    Console.WriteLine("{0}\n-> İsteğiniz doğrultuda hafızamdaki [{1}] verisini başarılı bir şekilde getirdim.\n{2}", mark, value, mark);
                }
                else
                {
                    Console.WriteLine("{0}\n-> Veri tabanı içerisinde henüz bir veri bulunmuyor. Lütfen daha sonra tekrar deneyin.\n{1}", mark, mark);
                }
            }

            public int login(string username, string password)
            {
                if (username == this.username && password == this.password)
                    return 1;
                else
                    return 0;
            }
        }
        class DatabaseManager
        {
            private IDatabase database;

            private string mark = new string('-', 6);
            public DatabaseManager(IDatabase database)
            {
                this.database = database;
            }
            public DatabaseManager()
            {
            }
            public void loginDB()
            {
                string username, password;
                Console.Write("{0}\n< Veri Tabanı Bağlantısı >\n{1}\n-> Kullanıcı adını girin: ", mark, mark);
                username = Console.ReadLine();
                Console.Write("-> Kullanıcı şifresini girin: ");
                password = Console.ReadLine();
                if (database.login(username, password) == 1)
                {
                    menu();
                }
                else
                {
                    Console.WriteLine("-> Bağlantı bilgilerini yanlış girdiniz, sistem kapatılıyor.\n{0}", mark);
                }
            }
            private void closeDB()
            {
                database.Close();
            }
            private void add(string value)
            {
                database.Add(value);
            }
            private void delete()
            {
                database.Delete();
            }
            private void get()
            {
                database.Get();
            }
            private void menu()
            {
                string value;
                int v;
                Console.WriteLine("< Veri Tabanı İşlemleri >\n{0}", mark);
                Console.WriteLine("[1] - Veri Ekle\n[2] - Veri Sil\n[3] - Veri Getir\n[4] - Bağlantıyı Kes\n{0}", mark);
                Console.Write("-> Yapmak istediğiniz işlem: ");
                v = Convert.ToInt32(Console.ReadLine());
                switch (v)
                {
                    case 1:
                        Console.Write("{0}\n-> Eklemek istediğiniz veri: ", mark);
                        value = Console.ReadLine();
                        add(value);
                        Console.WriteLine(mark);
                        Console.Clear();
                        menu();
                        break;
                    case 2:
                        Console.Clear();
                        delete();
                        menu();
                        break;
                    case 3:
                        Console.Clear();
                        get();
                        menu();
                        break;
                    case 4:
                        closeDB();
                        break;
                }
            }
        }

    }
}
