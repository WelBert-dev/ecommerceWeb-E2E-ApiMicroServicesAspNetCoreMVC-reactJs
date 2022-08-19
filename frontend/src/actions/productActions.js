// import Axios from 'axios'
import { 
    PRODUCT_LIST_FAIL, 
    PRODUCT_LIST_REQUEST, 
    PRODUCT_LIST_SUCCESS 
} from "../constants/productConstants"

import dataProducts from '../data';

export const listProducts = () => (dispatch) => {
    dispatch({type: PRODUCT_LIST_REQUEST, });

    try {
        // const { data } = await Axios.get('/api/products');
        const { products }  = dataProducts;
        dispatch({ type: PRODUCT_LIST_SUCCESS, payload: products });
    }
    catch (error)
    {
        dispatch({ type: PRODUCT_LIST_FAIL, payload: error.message })
    }
};
