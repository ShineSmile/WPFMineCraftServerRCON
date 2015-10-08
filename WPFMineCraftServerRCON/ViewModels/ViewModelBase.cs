using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace WPFMineCraftServerRCON.ViewModels
{
	public abstract class ViewModelBase
	{
		private event PropertyChangedEventHandler PropertyChanged;

		protected virtual void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
		{
			if (propertyExpression == null)
			{
				throw new ArgumentNullException("propertyExpression");
			}

			var memberExpression = propertyExpression.Body as MemberExpression;
			if (memberExpression == null)
			{
				throw new ArgumentException("It's not a member access expression!");
			}

			var property = memberExpression.Member as PropertyInfo;
			if (property == null)
			{
				throw new ArgumentException("It's not a property expression!");
			}

			var getMethod = property.GetGetMethod(true);
			if (getMethod.IsStatic)
			{
				throw new ArgumentException("Property of static class can not support!");
			}
			RaisePropertyChanged(memberExpression.Member.Name);
		}
	}
}
