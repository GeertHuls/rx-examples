using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RxDotnet
{
	public class UtilFunctionTests
	{
		[Fact]
		public async Task DoFunctionTest()
		{
			var observable = new[] { 1, 2, 3, 4, 5 }.ToObservable();

			await observable.Do(Console.WriteLine);

			await Task.Delay(5000);
		}

		/// <summary>
		/// Can be usefull for debugging purposes, when a certain
		/// event might have happend.
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task TimestampFunctionTest()
		{
			var observable = new[] { 1, 2, 3, 4, 5 }.ToObservable();

			await observable.Timestamp()
				.Do(val => Console.WriteLine(val));

			await Task.Delay(5000);
		}

		/// <summary>
		/// Throttle is used to reduce the rate of observables
		/// at the cost of losing intermediate values.
		/// Usefull for working with sensor data.
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task ThrottleFunctionTest()
		{
			var observable = new[] { 1, 2, 3, 4, 5 }.ToObservable();

			observable.Throttle(TimeSpan.FromSeconds(1))
				.Subscribe(new LoggerObserver<int>());

			await Task.Delay(5000);
		}
	}
}