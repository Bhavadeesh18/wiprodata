import { useDispatch, useSelector } from "react-redux";
import { bablu, bhavadeesh, nbr } from "./action";

const Names = () => {
    // Access the sname value from the Redux store
    const sname = useSelector( (state) => state.sname)
    // Get the dispatch function from Redux
    const dispatch = useDispatch();
    return (
        <div>
            <h1>Student Name is : {sname}</h1>
            <input type="button" value="Bablu" onClick={() => dispatch(bablu())} />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="Bhavadeesh" onClick={() => dispatch(bhavadeesh())} /> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="NBR" onClick={() => dispatch(nbr())} />
        </div>
    )
}

export default Names;