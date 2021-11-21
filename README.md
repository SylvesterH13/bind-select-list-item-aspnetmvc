# bind-select-list-item-aspnetmvc

This project shows how to do the model binding for a list of HTML select element on ASP.NET MVC when submitting a form.

The key aspect here is that the name of the input and selects must be on the following pattern:

```html
<tr>
  <td>
    <select name="WorksheetRates[0].GARateID">
      <option value="1">10</option>
      ...
    </select>
    <input hidden name="WorksheetRates[0].Id" /> 
  </td>
  ...
</tr>
<tr>
  <td>
    <select name="WorksheetRates[1].GARateID">
      <option value="1">500</option>
      ...
    </select>
    <input hidden name="WorksheetRates[1].Id" /> 
  </td>
  ...
</tr>
```
Models:

```cs
public class BudgetPrepViewModel
{
    public List<WorksheetRate> WorksheetRates { get; set; }
    ...
}
public class WorksheetRate
{
    public int Id { get; set; }
    public int GARateID { get; set; }
}
```
