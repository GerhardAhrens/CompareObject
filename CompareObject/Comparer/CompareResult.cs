//-----------------------------------------------------------------------
// <copyright file="CompareResult.cs" company="Lifeprojects.de">
//     Class: CompareResult
//     Copyright © Gerhard Ahrens, 2019
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>development@lifeprojects.de</email>
// <date>18.1.2019</date>
//
// <summary>Class for ObjectComparer Result</summary>
//-----------------------------------------------------------------------

namespace CompareObj
{
    using System;
    using System.Diagnostics;

    [DebuggerStepThrough]
    [Serializable]
    [DebuggerDisplay("Object={ObjectName}, PropertyName={PropertyName}, PropertyTyp={PropertyTyp}")]
    public class CompareResult
    {
        public CompareResult(string name, object firstValue, object secondValue)
        {
            this.PropertyName = name;
            this.FirstValue = firstValue;
            this.SecondValue = secondValue;
        }

        public CompareResult(string objectName, string name, string propertyTyp, object firstValue, object secondValue)
        {
            this.ObjectName = objectName;
            this.PropertyName = name;
            this.PropertyTyp = propertyTyp;
            this.FirstValue = firstValue;
            this.SecondValue = secondValue;
        }

        public string ObjectName { get; private set; }

        public string PropertyName { get; private set; }

        public string PropertyTyp { get; private set; }

        public object FirstValue { get; private set; }

        public object SecondValue { get; private set; }

        public string FullName
        {
            get { return $"{this.ObjectName}.({this.PropertyTyp}){this.PropertyName}; CurrentValue={this.NullToString(this.FirstValue)}; OldValue={this.NullToString(this.SecondValue)}"; }
        }

        public string ShortText
        {
            get
            {
                string op = string.Empty;
                if (this.FirstValue == null && this.SecondValue == null)
                {
                    op = "==";
                }
                else if (this.FirstValue != null && this.SecondValue != null)
                {
                    op = (this.FirstValue.Equals(SecondValue) ? " == " : " != ");
                }
                else if (this.FirstValue != null && this.SecondValue == null)
                {
                    op = "!=";
                }
                else if (this.FirstValue == null && this.SecondValue != null)
                {
                    op = "!=";
                }

                string result = $"[{this.PropertyName.PadRight(20)}] : {this.NullToString(this.FirstValue)} {op} {this.NullToString(this.SecondValue)}";
                return result;
            }
        }

        public override string ToString()
        {
            string op = string.Empty;
            if (this.FirstValue == null && this.SecondValue == null)
            {
                op = "==";
            }
            else if (this.FirstValue != null && this.SecondValue != null)
            {
                op = (this.FirstValue.Equals(SecondValue) ? " == " : " != ");
            }
            else if (this.FirstValue != null && this.SecondValue == null)
            {
                op = "!=";
            }
            else if (this.FirstValue == null && this.SecondValue != null)
            {
                op = "!=";
            }

            string result = $"{this.ObjectName}.{this.PropertyName} [{this.PropertyTyp}] : {NullToString(this.FirstValue)} {op} {NullToString(this.SecondValue)}";
            return result;
        }

        private string NullToString(object value)
        {
            return string.IsNullOrEmpty(value.ToString()) ==true ? "null" : value.ToString();
        }
    }
}