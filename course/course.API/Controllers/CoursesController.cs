using course.API.Filters;
using course.Application.DataTransferObjects.Requests;
using course.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace course.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _courseService.GetCourseAsync(id);
            if (course != null)
            {
                return Ok(course);
            }
            return NotFound(new { message = $"{id} id'li bir kurs bulunamadı" });
        }
        [HttpGet("Ara/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(string title)
        {
            var courses = await _courseService.GetCoursesByTitle(title);
            return Ok(courses);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateNewCourseRequest createNewCourseRequest)
        {
            if (ModelState.IsValid)
            {
                var createdCourseId = await _courseService.CreateNewCourse(createNewCourseRequest);
                return CreatedAtAction(nameof(GetCourse), routeValues: new { id = createdCourseId }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [NullReference]
        [IsExists]
        public async Task<IActionResult> Update(int id, UpdateCourseRequest updateCourseRequest)
        {
            //if (await _courseService.IsExists(id))
            //{
            if (id == updateCourseRequest.Id && ModelState.IsValid)
            {
                await _courseService.UpdateCourse(updateCourseRequest);
                //throw new NullReferenceException($"bilmemne nesnesi null olamaz");
                return Ok();
            }
            return BadRequest(ModelState);
            //}
            //return NotFound();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Delete(int id)
        {
            //if (await _courseService.IsExists(id))
            //{
            await _courseService.DeleteCourse(id);
            return Ok();
            //}
            //return NotFound();
        }

    }
}
