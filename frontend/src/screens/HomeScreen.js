import React, { useEffect, useState } from 'react';
import axios from 'axios';

import MainCardProduct from '../components/MainCardProduct';
import LoadingBox from '../components/LoadingBox';
import MessageBox from '../components/MessageBox';

import dataStore from  '../data';

export default function HomeScreen() {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);

    useEffect(() => {
      const fetchData = async () => {
        try 
        {
          setLoading(true);
          const data  = dataStore.products;
          setProducts(data);
          setLoading(false);
        }
        catch(err)
        {
          setLoading(false);
          setError(err.message);
        }
        
      };
      fetchData();
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
                <MainCardProduct key={product._id} product={product} showLink={true}/>
              ))
            }         
          </div>
        )}
        
      </div>
        
  )
}
