using DeliciousPieShop.Controllers;
using DeliciousPieShop.ViewModel;
using DeliciousPieShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeliciousPieShopTests.Controllers
{
    public class PieControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnsAllPies()
        {
            //arrange
            var mockPieRepository = RepositoryMocks.GetPieRepository();
            var mockcategoryRepository = RepositoryMocks.GetCategoryRepository();
            var pieController = new PieController(mockPieRepository.Object, mockcategoryRepository.Object);

            //act
            var result = pieController.List("");

            //assert
            var viewresult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>
                (viewresult.ViewData.Model);
            Assert.Equal(10, pieListViewModel.Pies.Count());


        }
    }
}
