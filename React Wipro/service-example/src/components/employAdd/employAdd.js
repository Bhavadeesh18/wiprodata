import React, {useState} from 'react';
import axios from 'axios';

const EmployAdd = () => {
    const [employ, setEmploy] = useState({
        empno: '',
        name: '',
        gender: '',
        dept: '',
        desig: '',
        basic: ''
    });

    const handleChange = (e) => {
        setEmploy({
            ...employ,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        axios.post('https://localhost:7174/api/EmploysNew', employ)
            .then(response => {
                alert('Employee added successfully!');
                setEmploy({
                    empno: '',
                    name: '',
                    gender: '',
                    dept: '',
                    desig: '',
                    basic: ''
                });
            })
            .catch(error => {
                console.error('Error adding employee:', error);
                alert('Error adding employee');
            });
    };

    return (
        <div>
            <h3>Add Employee</h3>
            <form onSubmit={handleSubmit}>
                <label>Employ No: </label>
                <input type="number" name="empno" value={employ.empno} onChange={handleChange} required /><br/><br/>
                
                <label>Name: </label>
                <input type="text" name="name" value={employ.name} onChange={handleChange} required /><br/><br/>
                
                <label>Gender: </label>
                <select name="gender" value={employ.gender} onChange={handleChange} required>
                    <option value="">Select</option>
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                </select><br/><br/>
                
                <label>Department: </label>
                <input type="text" name="dept" value={employ.dept} onChange={handleChange} required /><br/><br/>
                
                <label>Designation: </label>
                <input type="text" name="desig" value={employ.desig} onChange={handleChange} required /><br/><br/>
                
                <label>Basic: </label>
                <input type="number" name="basic" value={employ.basic} onChange={handleChange} required /><br/><br/>
                
                <input type="submit" value="Add Employee" />
            </form>
        </div>
    );
};

export default EmployAdd;