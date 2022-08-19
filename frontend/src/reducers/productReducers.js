const { 
    PRODUCT_LIST_FAIL, 
    PRODUCT_LIST_REQUEST, 
    PRODUCT_LIST_SUCCESS 
} = require("../constants/productConstants");

export const productListReducer = (state = { products: [] }, action) => {
    console.log(action.type);
    switch (action.type)
    {
        case PRODUCT_LIST_REQUEST:
            return {loading: true};

        case PRODUCT_LIST_SUCCESS:
            console.log(action.payload);
            return {loading: false, products: action.payload};

        case PRODUCT_LIST_FAIL:
            console.log("fail reducer area");
            return {loading: false, error: action.payload};

        default:
            return state;
    }
};
