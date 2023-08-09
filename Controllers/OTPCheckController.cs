
    public class OTPCheckController : Controller
    {
        private readonly ILogger<OTPCheckController> _logger;


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GenerateOtp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendOtp()
        {
            string num = "123456";
            int len = num.Length;
            string otp = string.Empty;
            int otpDigit = 6;
            string finalDigit;
            int getIndex;

            for (int i = 0; i < otpDigit; i++)
            {

                do
                {
                    getIndex = new Random().Next(0, len);
                    finalDigit = num.ToCharArray()[getIndex].ToString();
                } while (otp.IndexOf(finalDigit) != -1);
                otp += finalDigit;

            }
            TempData["otp"] = otp;
            TempData["timestamp"] = DateTime.Now;
            return RedirectToAction("GenerateOtp", "Home");

        }

        [HttpGet]

        public IActionResult SubmitOtp( int finalDigit)
        {
            string filepath = @"/home/ict/Desktop\OTPFile.txt";
      
            string OTP = 123456;       
            var lines = File.ReadAllLines(filepath);
            
            if(OTP == line){
                Console.WriteLine("OTP accepted");
            }
            else if ((DateTime.Now - Convert.ToDateTime(TempData["timestamp"])).TotalSeconds > 30)
            {
                return BadRequest("OTP Timedout");
            }
            else
            {
                return BadRequest("Please Enter Valid OTP");
            }
        }

    }
