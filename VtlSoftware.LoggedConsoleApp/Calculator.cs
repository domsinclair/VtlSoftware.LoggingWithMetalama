////////////////////////////////////////////////////////////////////////////////////////////////////
// <copyright file="Calculator.cs" company="View To Learn / Vtl Software Ltd">
// Copyright (c) 2023 View To Learn / Vtl Software Ltd. All rights reserved.
// </copyright>
// <author>Dom Sinclair</author>
// <date>Wednesday, 10 May 2023</date>
// <summary>Implements the calculator class</summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using Vtl.LogToConsole;

namespace VtlSoftware.LoggedConsoleApp
{
    /// <summary>
    /// A calculator. This class contains four methods providing basic arithmetic functions. There is no default
    /// constructor.
    /// </summary>
    internal partial class Calculator
    {
        #region Public Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
/// Adds.
/// </summary>
        ///
        /// <param name="a">A double to process.</param>
        /// <param name="b">A double to process.</param>
        ///
        /// <returns>A double.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NoLog]
        public double Add(double a, double b) => a + b;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Divides.
        /// </summary>
        ///
        /// <param name="a">A double to process.</param>
        /// <param name="b">A double to process.</param>
        ///
        /// <returns>A double.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public double Divide(double a, double b) => a / b;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Multiplies.
        /// </summary>
        ///
        /// <param name="a">A double to process.</param>
        /// <param name="b">A double to process.</param>
        ///
        /// <returns>A double.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public double Multiply(double a, double b) => a * b;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Subtracts.
        /// </summary>
        ///
        /// <param name="a">A double to process.</param>
        /// <param name="b">A double to process.</param>
        ///
        /// <returns>A double.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public double Subtract(double a, double b) => a - b;

        #endregion
    }
}
