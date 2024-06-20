using Clinic.Controllers;
using Clinic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueTests.ControllerTests
{
    public class EmploiControllerTests
    {
        [Fact]
        public async Task Create_ValidModelState_ReturnsRedirectToActionResult()
        {
            var mockContext = new Mock<ClinicDbContext>(); // Remplacez ClinicDbContext par votre propre contexte
            var mockLogger = new Mock<ILogger<EmployeController>>();
            var controller = new EmployeController(mockContext.Object, mockLogger.Object);
            var newEmployee = new Employee
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Sex = "Male",
                PhoneNumber = "1234567890",
                Nationality = "USA",
                Password = "password123",
                RecruitmentDate = DateTime.Now.Date,
                City = "New York",
                IsChefDeService = true,
                TotalWeeklyHours = 40,
                CategorieId = 1,
                EmploiId = 2,
                ServiceId = 3,
                Approved = true
            };

            // Act
            var result = await controller.Create(newEmployee) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName); // Assurez-vous que l'action de redirection est correcte
        }
        [Fact]
        public async Task DeleteEmployee_ExistingEmployeeName_ReturnsRedirectToActionResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ClinicDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ClinicDbContext(options))
            {
                // Ajouter un employé de test dans la base de données en mémoire
                var employee = new Employee { EmployeeId = 1, Name = "John Doe" };
                context.Employee.Add(employee);
                context.SaveChanges();

                // Mock du logger
                var mockLogger = new Mock<ILogger<EmployeController>>();

                // Créer une instance du contrôleur avec le contexte en mémoire et le mock du logger
                var controller = new EmployeController(context, mockLogger.Object);

                // Act
                var result = await controller.DeleteEmployee("John Doe") as RedirectToActionResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Index", result.ActionName); // Assurez-vous que l'action de redirection est correcte
            }
        }
        [Fact]
        public async Task DeleteEmployee_NonExistingEmployeeName_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ClinicDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ClinicDbContext(options))
            {
                // Mock du logger
                var mockLogger = new Mock<ILogger<EmployeController>>();

                // Créer une instance du contrôleur avec le contexte en mémoire et le mock du logger
                var controller = new EmployeController(context, mockLogger.Object);

                // Act
                var result = await controller.DeleteEmployee("NonExistingEmployeeName") as NotFoundResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal(404, result.StatusCode); // Assurez-vous que le statut de retour est NotFound (404)
            }
        }

        [Fact]
        public void PopulateServiceList_ServicesExist_PopulatesViewBag()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ClinicDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ClinicDbContext(options))
            {
                // Ajouter des services de test dans la base de données en mémoire
                var services = new List<Service>
                {
                    new Service { Id = 1, Name = "Service 1" },
                    new Service { Id = 2, Name = "Service 2" }
                };
                context.Services.AddRange(services);
                context.SaveChanges();

                // Mock du logger
                var mockLogger = new Mock<ILogger<EmployeController>>();

                // Créer une instance du contrôleur avec le contexte en mémoire et le mock du logger
                var controller = new EmployeController(context, mockLogger.Object);

                // Act
                controller.PopulateServiceList();

                // Assert
                Assert.NotNull(controller.ViewBag.ServiceList);
                Assert.IsType<SelectList>(controller.ViewBag.ServiceList);

                var serviceList = (controller.ViewBag.ServiceList as SelectList).ToList();
                Assert.Equal(2, serviceList.Count);

                Assert.Equal("1", serviceList[0].Value);
                Assert.Equal("Service 1", serviceList[0].Text);

                Assert.Equal("2", serviceList[1].Value);
                Assert.Equal("Service 2", serviceList[1].Text);
            }
        }
    }
}
