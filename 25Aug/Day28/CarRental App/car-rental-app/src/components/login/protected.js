import { useState } from "react";
import ProtectedService from "../../services/ProtectedService";

const Protected = () => {
  const [cars, setCars] = useState([]);
  const [newVehicle, setNewVehicle] = useState({ make: '', model: '', year: '', dailyRate: '', passengerCapacity: '', engineCapacity: '', vehicleType: 'Sedan' });
  const [editingVehicle, setEditingVehicle] = useState(null);
  const protectedService = ProtectedService();

  const show = async () => {
    try {
      const response = await protectedService.adminDashBoard(); 
      setCars(response.data);
    } catch (error) {
      console.error("Error fetching cars", error);
    }
  };

  const addVehicle = async () => {
    try {
      await protectedService.addVehicle(newVehicle);
      setNewVehicle({ make: '', model: '', year: '', dailyRate: '', passengerCapacity: '', engineCapacity: '', vehicleType: 'Sedan' });
      show();
    } catch (error) {
      console.error("Error adding vehicle", error);
    }
  };

  const updateVehicle = async () => {
    try {
      await protectedService.updateVehicle(editingVehicle.vehicleID, editingVehicle);
      setEditingVehicle(null);
      show();
    } catch (error) {
      console.error("Error updating vehicle", error);
    }
  };

  const deleteVehicle = async (id) => {
    try {
      await protectedService.deleteVehicle(id);
      show();
    } catch (error) {
      console.error("Error deleting vehicle", error);
    }
  };

  return (
    <div className="container mt-4">
      {/* Add Vehicle Form */}
      <div className="card mb-4">
        <div className="card-body">
          <h5>Add New Vehicle</h5>
          <div className="row mb-3">
            <div className="col-md-2">
              <input className="form-control" placeholder="Make" value={newVehicle.make} onChange={(e) => setNewVehicle({...newVehicle, make: e.target.value})} />
            </div>
            <div className="col-md-2">
              <input className="form-control" placeholder="Model" value={newVehicle.model} onChange={(e) => setNewVehicle({...newVehicle, model: e.target.value})} />
            </div>
            <div className="col-md-2">
              <input className="form-control" placeholder="Year" type="number" value={newVehicle.year} onChange={(e) => setNewVehicle({...newVehicle, year: e.target.value})} />
            </div>
            <div className="col-md-2">
              <input className="form-control" placeholder="Daily Rate" type="number" step="0.01" value={newVehicle.dailyRate} onChange={(e) => setNewVehicle({...newVehicle, dailyRate: e.target.value})} />
            </div>
            <div className="col-md-2">
              <input className="form-control" placeholder="Passenger Capacity" type="number" value={newVehicle.passengerCapacity} onChange={(e) => setNewVehicle({...newVehicle, passengerCapacity: e.target.value})} />
            </div>
            <div className="col-md-2">
              <input className="form-control" placeholder="Engine Capacity" type="number" step="0.01" value={newVehicle.engineCapacity} onChange={(e) => setNewVehicle({...newVehicle, engineCapacity: e.target.value})} />
            </div>
          </div>
          <div className="row">
            <div className="col-md-2">
              <button className="btn btn-success" onClick={addVehicle}>Add Vehicle</button>
            </div>
          </div>
        </div>
      </div>

      <table border="3" align="center" className="table table-striped table-bordered">
        <thead className="table-dark">
          <tr>
            <th>Vehicle Id</th>
            <th>Make</th>
            <th>Model</th>
            <th>Year</th>
            <th>Daily Rate</th>
            <th>Status</th>
            <th>Passenger Capacity</th>
            <th>Engine Capacity</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {cars.map((item) => (
            <tr key={item.vehicleID}>
              <td>{item.vehicleID}</td>
              <td>{editingVehicle?.vehicleID === item.vehicleID ? 
                <input value={editingVehicle.make} onChange={(e) => setEditingVehicle({...editingVehicle, make: e.target.value})} /> : item.make}
              </td>
              <td>{editingVehicle?.vehicleID === item.vehicleID ? 
                <input value={editingVehicle.model} onChange={(e) => setEditingVehicle({...editingVehicle, model: e.target.value})} /> : item.model}
              </td>
              <td>{editingVehicle?.vehicleID === item.vehicleID ? 
                <input value={editingVehicle.year} onChange={(e) => setEditingVehicle({...editingVehicle, year: e.target.value})} /> : item.year}
              </td>
              <td>{editingVehicle?.vehicleID === item.vehicleID ? 
                <input value={editingVehicle.dailyRate} onChange={(e) => setEditingVehicle({...editingVehicle, dailyRate: e.target.value})} /> : item.dailyRate}
              </td>
              <td>{item.status}</td>
              <td>{item.passengerCapacity}</td>
              <td>{item.engineCapacity}</td>
              <td>
                {editingVehicle?.vehicleID === item.vehicleID ? (
                  <>
                    <button className="btn btn-success btn-sm me-2" onClick={updateVehicle}>Save</button>
                    <button className="btn btn-secondary btn-sm" onClick={() => setEditingVehicle(null)}>Cancel</button>
                  </>
                ) : (
                  <>
                    <button className="btn btn-warning btn-sm me-2" onClick={() => setEditingVehicle(item)}>Edit</button>
                    <button className="btn btn-danger btn-sm" onClick={() => deleteVehicle(item.vehicleID)}>Delete</button>
                  </>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <input type="button" value="Show Protected" onClick={show} className="btn btn-primary" /> <br /><br />
    </div>
  );
};

export default Protected;