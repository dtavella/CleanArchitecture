namespace Core.Services.Implementatios
{
    public class StudentServiceAsync
    {
        public async Task TestAsync()
        {
            Console.WriteLine("TestAsync Inicio");

            Console.WriteLine("1");
            var t1 =  T1();
            Console.WriteLine("2");
            var t2 = T2();
            Console.WriteLine("3");
            var t3 = T3();
            Console.WriteLine("4");

            await t1;
            await t2;
            await t3;

            Console.WriteLine("TestAsync Fin");
        }

        public async Task T1()
        {
            Console.WriteLine("T1 Inicio");
            await Task.Delay(1000);
            Console.WriteLine("T1 fin");
        }

        public async Task T2()
        {
            Console.WriteLine("T2 Inicio");
            await Task.Delay(1000);
            Console.WriteLine("T2 fin");
        }

        public async Task T3()
        {
            Console.WriteLine("T3 Inicio");
            await Task.Delay(3000);
            Console.WriteLine("T3 fin");
        }
    }
}
