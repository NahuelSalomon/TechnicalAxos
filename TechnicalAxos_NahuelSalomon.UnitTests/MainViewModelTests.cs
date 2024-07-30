using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAxos_NahuelSalomon.Services;
using Xunit;

namespace TechnicalAxos_NahuelSalomon.UnitTests
{
    public class MainViewModelTests
    {
        [Fact]
        private void SetPackageName() 
        {
            // Arrange
            var mockAppInfoService = Substitute.For<IAppInfoService>();
            mockAppInfoService.GetAppIdentifier().Returns("com.example.app");
            
            //Act
            var mainViewModel = new MainViewModel();
            mainViewModel.SetPackageName();

            //Assert
            mainViewModel.PackageName.Should().Be("com.example.app");
        }

    }
}
