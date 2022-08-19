import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import MainCardProduct from '../components/MainCardProduct';
import LoadingBox from '../components/LoadingBox';
import MessageBox from '../components/MessageBox';

import { listProducts } from '../actions/productActions';

export default function HomeScreen() {
    
    const dispatch = useDispatch();
    const productList = useSelector( (state) => state.productList ); // from /src/store.js redux
    const { loading, error, products } = productList;

    useEffect(() => {
      dispatch(listProducts());
    }, []);

    return (
      <div>
        {loading ? (
          <LoadingBox></LoadingBox>
        ) : error ? (
          <MessageBox variant="danger">{error}</MessageBox>
        ) : (
          <div className="row center">
            {
              products.map(product => (
                <MainCardProduct key={product.id} product={product} showLink={true}/>
              ))
            }         
          </div>
        )}
        
      </div>
        
  )
}
