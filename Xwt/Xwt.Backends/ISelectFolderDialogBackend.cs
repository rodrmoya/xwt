// 
// ISelectFolderDialog.cs
//  
// Author:
//       Lluis Sanchez <lluis@xamarin.com>
// 
// Copyright (c) 2012 Xamarin Inc
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;

namespace Xwt.Backends
{
	public interface ISelectFolderDialogBackend: IBackend
	{
		/// <summary>
		/// Initializes the folder selector dialog. This method can be called multiple times.
		/// </summary>
		/// <param name='multiselect'>
		/// Value indicating whether the user can select multiple folders
		/// </param>
		void Initialize (bool multiselect);
		
		/// <summary>
		/// Gets or sets the title of the dialog
		/// </summary>
		string Title { get; set; }
			
		/// <summary>
		/// Gets the path of the folder that the user has selected in the dialog
		/// </summary>
		/// <value>
		/// The name of the folder, or null if no selection was made
		/// </value>
		/// <remarks>
		/// This property can be invoked at any time after a call to Initialize, and before the call to Close.
		/// </remarks>
		string Folder { get; }

		/// <summary>
		/// Gets the paths of the folders that the user has selected in the dialog
		/// </summary>
		/// <value>
		/// The paths of the folders
		/// </value>
		/// <remarks>
		/// This property can be invoked at any time after a call to Initialize, and before the call to Close
		/// </remarks>
		string[] Folders { get; }

		/// <summary>
		/// Gets or sets the folder whose contents are shown in the dialog
		/// </summary>
		/// <value>
		/// The current folder.
		/// </value>
		/// <remarks>
		/// This property can be invoked at any time after a call to Initialize, and before the call to Close
		/// </remarks>
		string CurrentFolder { get; set; }

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		/// <param name='parent'>
		/// Parent window (the dialog will be modal to this window). It can be null.
		/// </param>
		/// <remarks>
		/// The Run method will always be called once (and only once) after an Initialize call.
		/// </remarks>
		bool Run (IWindowFrameBackend parent);
		
		/// <summary>
		/// Closes the dialog.
		/// </summary>
		/// <remarks>
		/// This method is called after Run, so that the backend can release
		/// the native resources. The Initialize method can be called after Close.
		/// </remarks>
		void Close ();	
	}
}

