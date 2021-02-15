using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReprterFeature;

namespace ReporterTests
{
    // https://habr.com/ru/post/82842/
    // https://github.com/Moq/moq4/wiki/Quickstart
    /*
     * Задача состоит из нескольких подзадач: 
     * 1) написать консольное приложение, которое отправляет отчеты. 
     * 2) Каждый второй сформированный отчет надо отправлять ещё и аудиторам. 
     * 3) Если ни одного отчета не сформировано, то отправляем сообщение руководству о том, что отчетов нет. 
     * 4) После отправки всех отчётов, нужно вывести в консоль количество отправленных.
     */

    // Вопрос: Надо ли стремиться покрыть код тестами на 100%? Нет. Нормальное прокрытие колеблется от 50 до 90%. 
    // Т.е. должна быть покрыта вся бизнес-логика без обращений к базе данных, внешним сервисам и файловой системе.

    [TestClass]
    public class ReporterTests
    {
        [TestMethod]
        public void ReturnNumberOfSentReports()
        {
            var reportBuilder = new Mock<IReportBuilder>();
            var reportSender = new Mock<IReportSender>();

            reportBuilder.Setup(m => m.CreateRegularReports())
                .Returns(new List<IReport> { new Report(), new Report() });

            var reporter = new Reporter(reportBuilder.Object, reportSender.Object);

            var reportCount = reporter.SendReports();

            Assert.AreEqual(2, reportCount);
        }

        [TestMethod]
        public void SendAllReports() {
            // Arrange (Устанавливаем) – производим настройку входных данных для теста.
            var reportBuilder = new Mock<IReportBuilder>();
            var reportSender = new Mock<IReportSender>();

            reportBuilder.Setup(m => m.CreateRegularReports())
              .Returns(new List<IReport> { new Report(), new Report() });

            var reporter = new Reporter(reportBuilder.Object, reportSender.Object);

            // Act (Действуем) – выполняем действие, результаты которого тестируем. 
            reporter.SendReports();

            // Assert (Проверяем) – проверяем результаты выполнения.
            reportSender.Verify(m => m.Send(It.IsAny<Report>()), Times.Exactly(2));
        }

        [TestMethod]
        public void SendSpecialReportToAdministratorIfNoReportsCreated() {
            var reportBuilder = new Mock<IReportBuilder>();
            var reportSender = new Mock<IReportSender>();

            reportBuilder.Setup(m => m.CreateRegularReports()).Returns(new List<IReport>());
            reportBuilder.Setup(m => m.CreateSpecialReport()).Returns(new SpecialReport());

            var reporter = new Reporter(reportBuilder.Object, reportSender.Object);

            reporter.SendReports();

            reportSender.Verify(m => m.Send(It.IsAny<Report>()), Times.Never());
            reportSender.Verify(m => m.Send(It.IsAny<SpecialReport>()), Times.Once());
        }
    }
}
