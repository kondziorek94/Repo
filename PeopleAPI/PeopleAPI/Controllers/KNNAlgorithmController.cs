using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeopleAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KNNAlgorithmController : ControllerBase
    {
        private static readonly int[] Days = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        private static readonly String[] Outlook = new String[] { "Sunny", "Sunny", "Overcast", "Rain", "Rain", "Rain", "Overcast", "Sunny", "Sunny", "Rain", "Sunny", "Overcast", "Overcast", "Rain" };
        private static readonly int[] Temperatures = new[] { 85, 80, 83, 70, 68, 65, 64, 72, 69, 75, 75, 72, 81, 71 };
        private static readonly int[] Humidity = new int[] { 85, 90, 78, 96, 80, 70, 65, 95, 70, 80, 70, 90, 75, 80 };
        private static readonly String[] Wind = new String[] { "Weak", "Strong", "Weak", "Weak", "Weak", "Strong", "Strong", "Weak", "Weak", "Weak", "Strong", "Strong", "Weak", "Strong" };
        private static readonly String[] Decision = new String[] { "No", "No", "Yes", "Yes", "Yes", "No", "Yes", "No", "Yes", "Yes", "Yes", "Yes", "Yes", "No" };
    }
}