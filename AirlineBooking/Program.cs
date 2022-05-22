namespace AirlineBooking
{

    class CobRef
    {
        public string Value { get; set; }
    }

    class ImplCobaRef
    {
     
        private void _ubahRef(ref string value)
        {
            value = "123";
        }

        private void _ubahNonRef(string value)
        {
            value = "456";
        }

        private void _ubahRef2(ref string value)
        {
            value = "789";
        }

        public void Create()
        {
            string val = "";

            _ubahRef(ref val);
            _ubahNonRef(val);

            _ubahRef2(ref val);

            Console.WriteLine(val);

        }
    }

    class Program
    {
        

        static void Main(string[] args)
        {
            var _implCobaRef = new ImplCobaRef();
            _implCobaRef.Create();  
        }
    }
}