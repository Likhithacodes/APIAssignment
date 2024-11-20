using Microsoft.AspNetCore.Mvc;
using APIAssignment.Modals;
namespace APIAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankController : Controller
    {
        static List<BloodBankEntry> BankList = new List<BloodBankEntry>
       {
           new BloodBankEntry{Id=1,DonorName="Likhitha",Age=21,BloodType="B+",ContactInfo="likhitha@gmail.com",Quantity=300,CollectionDate=DateTime.Now,ExpirationDate=new DateTime(2024,11,25),Status="Available" },
           new BloodBankEntry{Id=2,DonorName="sreeja",Age=22,BloodType="A+",ContactInfo="sreeja@gmail.com",Quantity=500,CollectionDate=DateTime.Now,ExpirationDate = new DateTime(2024,11,28),Status="Requested" },
           new BloodBankEntry{Id=3,DonorName="janu",Age=23,BloodType="O+",ContactInfo="janu@gmail.com",Quantity=1000,CollectionDate=DateTime.Now,ExpirationDate=new DateTime(2024,11,11),Status="Expired" },
           new BloodBankEntry{Id=4,DonorName="keerthi",Age=24,BloodType="B+",ContactInfo="keerthi@gmail.com",Quantity=200,CollectionDate=DateTime.Now,ExpirationDate=new DateTime (2024,11,22),Status="Available" }

       };
        [HttpGet]
        public ActionResult<IEnumerable<BloodBankEntry>> GetAllEntries()
        {
            return Ok(BankList);
        }
        [HttpGet("{id}")]
        public ActionResult<BloodBankEntry> GetDetailsById(int id)
        {
            var res = BankList.Find(x => x.Id == id);
            if (res == null)
            {
                return NotFound("No Entry with such ID");
            }
            return res;
        }
        [HttpPost]
        public ActionResult<BloodBankEntry> PostDetails(BloodBankEntry entry)
        {
            // Validate the input
            if (entry == null)
            {
                return BadRequest("Entry cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(entry.DonorName))
            {
                return BadRequest("Donor name is required.");
            }

            if (string.IsNullOrWhiteSpace(entry.BloodType))
            {
                return BadRequest("Blood type is required.");
            }

            if (entry.Quantity <= 0)
            {
                return BadRequest("Quantity should be greater than zero.");
            }

            if (entry.CollectionDate == default || entry.ExpirationDate == default)
            {
                return BadRequest("Collection and expiration dates are required.");
            }
            if (entry.CollectionDate == entry.ExpirationDate) {
                return BadRequest("collectionDate and ExpirationDate are same then the Blood Cannot be Considered");
            }
            if (entry.Age < 18)
            {
                return BadRequest("Donor must be at least 18 years old.");
            }

            entry.Id = BankList.Any() ? BankList.Max(i => i.Id) + 1 : 1;
            BankList.Add(entry);
            return CreatedAtAction(nameof(GetDetailsById), new { id = entry.Id }, entry);
        }
        [HttpPut("{id}")]
        public ActionResult<BloodBankEntry> PostDetails(int id,BloodBankEntry input)
        {
            var entry = BankList.FirstOrDefault(i => i.Id == id);
            if (entry == null)
            {
                return NotFound("Entry Not Found");
            }
            // Update fields only if they are not null or default
            if (!string.IsNullOrEmpty(input.DonorName))
                entry.DonorName = input.DonorName;
            // Ensure age is a greater than 18
            if (input.Age > 18) 
                entry.Age = input.Age;

            if (!string.IsNullOrEmpty(input.BloodType))
                entry.BloodType = input.BloodType;

            if (!string.IsNullOrEmpty(input.ContactInfo))
                entry.ContactInfo = input.ContactInfo;

            if (input.Quantity > 0) 
                entry.Quantity = input.Quantity;

            if (input.CollectionDate != default(DateTime))
                entry.CollectionDate = input.CollectionDate;

            if (input.ExpirationDate != default(DateTime))
                entry.ExpirationDate = input.ExpirationDate;

            if (!string.IsNullOrEmpty(input.Status))
                entry.Status = input.Status;

            return Ok(entry);
            
        }
        [HttpDelete("{id}")]
        public ActionResult<BloodBankEntry> DeleteDetails(int id)
        {
            var entry = BankList.FirstOrDefault(i => i.Id == id);
            if (entry == null)
            {
                return NotFound("Entry Not found");
            };
            BankList.Remove(entry);
            return NoContent();
        }
        [HttpGet("Page")]
        
        public ActionResult<IEnumerable<BloodBankEntry>> GetAll(int page = 1, int size = 10, string? sortBy = null)
        {
            if (page <= 0 || size <= 0)
            {
                return BadRequest("Page and size parameters must be greater than 0.");
            }

            IEnumerable<BloodBankEntry> sortedList = BankList; 

            switch (sortBy?.ToLower())
            {
                case "BloodType":
                    sortedList = BankList.OrderBy(e => e.BloodType);
                    break;
                case "CollectionDate":
                    sortedList = BankList.OrderBy(e => e.CollectionDate);
                    break;
                default:
                    break;
            }

            var paginatedList = sortedList.Skip((page - 1) * size).Take(size).ToList();

            return Ok(paginatedList); 
        }
        [HttpGet("search")]
        public IActionResult SearchEntries(string? bloodType, string? status, string? donorName)
        {
            var results = BankList.AsQueryable();

            if (!string.IsNullOrWhiteSpace(bloodType))
                results = results.Where(e => e.BloodType.Contains(bloodType, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(status))
                results = results.Where(e => e.Status.Equals(status, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(donorName))
                results = results.Where(e => e.DonorName.Contains(donorName, StringComparison.OrdinalIgnoreCase));

            return Ok(results.ToList());
        }
        [HttpGet("Sort")]
        public ActionResult<IEnumerable<BloodBankEntry>> GetSortedDetails(
            string sortby = "BloodType",
            string sortorder = "asc",
            string? BloodType = null,
            string? Status = null)
        {
            // Filter the list based on the query parameters for blood type and status
            IEnumerable<BloodBankEntry> filteredList = BankList;

            if (!string.IsNullOrEmpty(BloodType))
            {
                filteredList = filteredList.Where(e => e.BloodType.Contains(BloodType, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(Status))
            {
                filteredList = filteredList.Where(e => e.Status.Equals(Status, StringComparison.OrdinalIgnoreCase));
            }

            // Apply sorting based on the `sortby` and `sortorder` parameters
            IQueryable<BloodBankEntry> sortedList = filteredList.AsQueryable();

            switch (sortby.ToLower())
            {
                case "bloodtype":
                    sortedList = sortorder.ToLower() == "asc"
                        ? sortedList.OrderBy(e => e.Age)
                        : sortedList.OrderByDescending(e => e.Age);
                    break;
                case "collectiondate":
                    sortedList = sortorder.ToLower() == "asc"
                        ? sortedList.OrderBy(e => e.CollectionDate)
                        : sortedList.OrderByDescending(e => e.CollectionDate);
                    break;
                default:
                    return BadRequest("Invalid sort field.");
            }

            // Return the sorted and filtered list
            return Ok(sortedList.ToList());
        }

    }
}
