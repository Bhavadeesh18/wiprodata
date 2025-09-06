import { useState, useEffect } from "react";
import CustomerService from "../../services/CustomerService";

const Customers = () => {
  const [customers, setCustomers] = useState([]);
  const [newCustomer, setNewCustomer] = useState({ firstName: '', lastName: '', email: '', phoneNumber: '' });
  const [editingCustomer, setEditingCustomer] = useState(null);
  const customerService = CustomerService();



  const showCustomers = async () => {
    try {
      console.log('Fetching customers...');
      const response = await customerService.getCustomers();
      console.log('Customers response:', response.data);
      setCustomers(response.data);
      alert(`Loaded ${response.data.length} customers`);
    } catch (error) {
      console.error("Error fetching customers:", error);
      alert(`Error loading customers: ${error.message}`);
    }
  };

  const addCustomer = async () => {
    try {
      await customerService.addCustomer(newCustomer);
      setNewCustomer({ firstName: '', lastName: '', email: '', phoneNumber: '' });
      showCustomers();
    } catch (error) {
      console.error("Error adding customer", error);
      alert(`Error: ${error.message}`);
    }
  };

  const updateCustomer = async () => {
    try {
      await customerService.updateCustomer(editingCustomer.customerID, editingCustomer);
      setEditingCustomer(null);
      showCustomers();
    } catch (error) {
      console.error("Error updating customer", error);
      alert(`Error: ${error.message}`);
    }
  };

  const deleteCustomer = async (id) => {
    if (window.confirm('Are you sure you want to delete this customer?')) {
      try {
        await customerService.deleteCustomer(id);
        showCustomers();
      } catch (error) {
        console.error("Error deleting customer", error);
        alert(`Error: ${error.message}`);
      }
    }
  };

  return (
    <div className="container mt-4">
      <h3>Customer Management</h3>
      
      {/* Add Customer Form */}
      <div className="card mb-4">
        <div className="card-body">
          <h5>Add New Customer</h5>
          <div className="row mb-3">
            <div className="col-md-3">
              <input className="form-control" placeholder="First Name" value={newCustomer.firstName} onChange={(e) => setNewCustomer({...newCustomer, firstName: e.target.value})} />
            </div>
            <div className="col-md-3">
              <input className="form-control" placeholder="Last Name" value={newCustomer.lastName} onChange={(e) => setNewCustomer({...newCustomer, lastName: e.target.value})} />
            </div>
            <div className="col-md-3">
              <input className="form-control" placeholder="Email" type="email" value={newCustomer.email} onChange={(e) => setNewCustomer({...newCustomer, email: e.target.value})} />
            </div>
            <div className="col-md-3">
              <input className="form-control" placeholder="Phone Number" value={newCustomer.phoneNumber} onChange={(e) => setNewCustomer({...newCustomer, phoneNumber: e.target.value})} />
            </div>
          </div>
          <button className="btn btn-success" onClick={addCustomer}>
            Add Customer
          </button>
        </div>
      </div>

      {/* Customer Table */}
      <table className="table table-striped table-bordered">
        <thead className="table-dark">
          <tr>
            <th>Customer ID</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Email</th>
            <th>Phone Number</th>
            <th>Created Date</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {customers.map((customer) => (
            <tr key={customer.customerID}>
              <td>{customer.customerID}</td>
              <td>
                {editingCustomer?.customerID === customer.customerID ? 
                  <input value={editingCustomer.firstName} onChange={(e) => setEditingCustomer({...editingCustomer, firstName: e.target.value})} /> 
                  : customer.firstName
                }
              </td>
              <td>
                {editingCustomer?.customerID === customer.customerID ? 
                  <input value={editingCustomer.lastName} onChange={(e) => setEditingCustomer({...editingCustomer, lastName: e.target.value})} /> 
                  : customer.lastName
                }
              </td>
              <td>
                {editingCustomer?.customerID === customer.customerID ? 
                  <input value={editingCustomer.email} onChange={(e) => setEditingCustomer({...editingCustomer, email: e.target.value})} /> 
                  : customer.email
                }
              </td>
              <td>
                {editingCustomer?.customerID === customer.customerID ? 
                  <input value={editingCustomer.phoneNumber} onChange={(e) => setEditingCustomer({...editingCustomer, phoneNumber: e.target.value})} /> 
                  : customer.phoneNumber
                }
              </td>
              <td>{new Date(customer.createdDate).toLocaleDateString()}</td>
              <td>
                {editingCustomer?.customerID === customer.customerID ? (
                  <>
                    <button className="btn btn-success btn-sm me-2" onClick={updateCustomer}>Save</button>
                    <button className="btn btn-secondary btn-sm" onClick={() => setEditingCustomer(null)}>Cancel</button>
                  </>
                ) : (
                  <>
                    <button className="btn btn-warning btn-sm me-2" onClick={() => setEditingCustomer(customer)}>Edit</button>
                    <button className="btn btn-danger btn-sm" onClick={() => deleteCustomer(customer.customerID)}>Delete</button>
                  </>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      
      <button className="btn btn-primary" onClick={showCustomers}>
        Show Customers
      </button>
    </div>
  );
};

export default Customers;