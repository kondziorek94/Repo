using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CarRentalWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        // public static Dictionary<string, string> bla = new Dictionary<string, string>(){{"fsa","fsa"}, {"",""}};
        public static Dictionary<string, ArithmeticOperation> EvaulationDictionary = new Dictionary<string, ArithmeticOperation> {
            { "+", (a, b) => a + b},
            { "-", (a, b) => a - b},
            { "*", (a, b) => a * b},
            { "/", (a, b) => a / b},
            { "%", (a, b) => a % b} };
        // GET: Calculator
        public ActionResult Index()
        {
            return RedirectToAction("Evaluate", new { a = 2, b = 5, op = "+" });
        }
        //zaimplementuj ponizsza metode bez uzycia ani jednej instrukcji warunkowej, petli itp.
        public ActionResult Evaluate(double a, double b, string op)
        {
            return View((object)("" + a + " " + op + " " + b + " = " + EvaulationDictionary[op](a, b)));
        }

        public ActionResult Calculator()
        {
            return View();
        }

        // rozbije 1 + 2 na a, b i operator i wywola metode Evaluate()
        public ActionResult EvaluateExpression(string expression)
        {
            expression = expression.Trim();
            string[] splitExpression = Regex.Split(expression, @"\s+");
            double a = Convert.ToDouble(splitExpression[0]);
            double b = Convert.ToDouble(splitExpression[2]);
            string op = splitExpression[1];
            return RedirectToAction("Evaluate", new { a, b, op });
        }

        [HttpPost]
        // rozbije 1 + 2 na a, b i operator i wywola metode Evaluate()
        public string EvaluateExpressionAJAX(string expression)
        {
            expression = expression.Trim();
            string pattern = @"^-?(\d+)*(?:\.\d+)?(\s+)(\+|\-|\*|/|\%)(\s+)-?(\d+)*(?:\.\d+)?$";
            if (Regex.IsMatch(expression,pattern)){
                //Asynchronous Java script And XML
                //JSON JavaSript Object Notation
                string[] splitExpression = Regex.Split(expression, @"\s+");
                double a = Convert.ToDouble(splitExpression[0]);
                double b = Convert.ToDouble(splitExpression[2]);
                string op = splitExpression[1];
                return EvaulationDictionary[op](a, b).ToString();
            }
            return "Expression is incorrect";
        }
        [HttpPost]
        public string GetSecuredData(string userName, string password)
        {
            string securedInfo = "";
            if ((userName == "admin") && (password == "admin"))
                securedInfo = "Hello admin, your secured information is .......";
            else
                securedInfo = "Wrong username or password, please retry.";
            return securedInfo;
        }

    }
}

public delegate double ArithmeticOperation(double a, double b);