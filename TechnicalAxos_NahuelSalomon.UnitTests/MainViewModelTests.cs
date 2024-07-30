using FluentAssertions;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAxos_NahuelSalomon.Models;
using TechnicalAxos_NahuelSalomon.Services;
using Xunit;

namespace TechnicalAxos_NahuelSalomon.UnitTests
{
    public class MainViewModelTests
    {
        [Fact]
        public async Task LoadCountries_Should_Fill_Countries_With_Data()
        {
            // Arrange
            var mockCountryService = new Mock<ICountryService>();

            var countries = new List<Country>
            {
                new Country { Independent = true },
                new Country { Independent = false }
            };

            mockCountryService.Setup(cs => cs.GetAllAsync()).ReturnsAsync(countries);

            var mainViewModel = new MainViewModel(mockCountryService.Object, false);

            // Act
            await mainViewModel.LoadCountriesCommand.ExecuteAsync(null);

            // Assert
            mainViewModel.Countries.Should().HaveCount(2);
            mainViewModel.Countries[0].Independent.Should().Be(true);
            mainViewModel.Countries[1].Independent.Should().Be(false);
        }

        [Fact]
        public async Task LoadCountries_Should_Initialize_Countries_As_Empty_Collection_If_No_Data()
        {
            // Arrange
            var mockCountryService = new Mock<ICountryService>();
            mockCountryService.Setup(cs => cs.GetAllAsync()).ReturnsAsync(new List<Country>());

            var mainViewModel = new MainViewModel(mockCountryService.Object, false);

            // Act
            await mainViewModel.LoadCountriesCommand.ExecuteAsync(null);

            // Assert
            mainViewModel.Countries.Should().BeEmpty();
        }
    }
}
