# WPF MVVM Template

![Screenshot of the app](./screenshot.png)

## 🎯 Goal

Provide a template to start a new WPF project using the MVVM architecture pattern.

## 💼 Content

- Navbar to navigate between views
- View displaying static content
- View to manage a customer list (CRUD)
- MVVM utilities

## 🔎 Structure

### WpfMvvm.Business

Contains all the business rules and the business objects.

### WpfMvvm.Data

Contains the logic to manage the data.  
Currently, only in memory data storage is available.  
However, the solution is decoupled and allow you to easily add any extra method.

### WpfMvvm.Front

Contains the UI.

## ❓ Q&A

### Why did you use DotNet Framework instead of DotNet Core?

I did this template with specific requirements for another projet.  
The aim was to use this one as a proof of concept to see if it could work in our environment.
