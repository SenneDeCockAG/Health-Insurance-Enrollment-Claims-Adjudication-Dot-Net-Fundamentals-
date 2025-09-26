
using System.Numerics;

namespace eHealthApp.Tests;

using Console.Models;
using eHealthApp.Business;
using eHealthApp.Services.Data;
using Moq;

[TestClass]
public class PlanBusinessTests
{
    [TestMethod]
    public void CreatePlan_ShouldCallSaveOnDataService()
    {
        var mockService = new Mock<IDataService<Plan>>();
        var planBusiness = new PlanBusiness(mockService.Object);
        var plan = new Plan { PlanCode = "123", PlanName = "Test Plan" };

        planBusiness.CreatePlan(plan);

        mockService.Verify(s => s.Save(plan), Times.Once);
    }

    [TestMethod]
    public void DeletePlan_ShouldCallDeleteOnDataService()
    {
        var mockService = new Mock<IDataService<Plan>>();
        var planBusiness = new PlanBusiness(mockService.Object);
        var plan = new Plan { PlanCode = "123", PlanName = "Test Plan" };

        var result = planBusiness.DeletePlan(plan);

        mockService.Verify(s => s.Delete(plan), Times.Once);
        Assert.IsTrue(result);
    }
}
