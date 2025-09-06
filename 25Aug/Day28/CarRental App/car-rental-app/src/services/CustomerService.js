import axios from "axios";

const CustomerService = () => {
    const getCustomers = async () => {
        try {
            const response = await axios.get("https://localhost:7161/api/customer");
            return response;
        } catch (error) {
            console.error("Error fetching customers", error);
            throw error;
        }
    };

    const addCustomer = async (customerData) => {
        try {
            const response = await axios.post("https://localhost:7161/api/customer", customerData, {
                headers: { 'Content-Type': 'application/json' }
            });
            return response;
        } catch (error) {
            console.error("Error adding customer", error);
            throw error;
        }
    };

    const updateCustomer = async (id, customerData) => {
        try {
            const response = await axios.put(`https://localhost:7161/api/customer/${id}`, customerData, {
                headers: { 'Content-Type': 'application/json' }
            });
            return response;
        } catch (error) {
            console.error("Error updating customer", error);
            throw error;
        }
    };

    const deleteCustomer = async (id) => {
        try {
            const response = await axios.delete(`https://localhost:7161/api/customer/${id}`);
            return response;
        } catch (error) {
            console.error("Error deleting customer", error);
            throw error;
        }
    };

    return {
        getCustomers,
        addCustomer,
        updateCustomer,
        deleteCustomer
    };
};

export default CustomerService;