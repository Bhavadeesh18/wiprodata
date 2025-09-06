import axios from "axios";
import AuthHeader from "./AuthHeader";

const ProtectedService = () => {
    const adminDashBoard = async () => {
        try {
            const response = await axios.get("https://localhost:7161/api/vehicle", {
                headers: AuthHeader()
            });
            return response;
        } catch (error) {
            console.error("Error fetching vehicles", error);
            throw error;
        }
    };

    const addVehicle = async (vehicleData) => {
        try {
            const response = await axios.post("https://localhost:7161/api/vehicle", vehicleData, {
                headers: AuthHeader()
            });
            return response;
        } catch (error) {
            console.error("Error adding vehicle", error);
            throw error;
        }
    };

    const updateVehicle = async (id, vehicleData) => {
        try {
            const response = await axios.put(`https://localhost:7161/api/vehicle/${id}`, vehicleData, {
                headers: AuthHeader()
            });
            return response;
        } catch (error) {
            console.error("Error updating vehicle", error);
            throw error;
        }
    };

    const deleteVehicle = async (id) => {
        try {
            const response = await axios.delete(`https://localhost:7161/api/vehicle/${id}`, {
                headers: AuthHeader()
            });
            return response;
        } catch (error) {
            console.error("Error deleting vehicle", error);
            throw error;
        }
    };

    return {
        adminDashBoard,
        addVehicle,
        updateVehicle,
        deleteVehicle
    };
};

export default ProtectedService;