import { createStore } from "@reduxjs/toolkit";
import NameReducer from "./NameReducers";
const Store = createStore(NameReducer);

export default Store;