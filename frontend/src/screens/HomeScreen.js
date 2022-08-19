import React, { useEffect, useState } from 'react';

import MainCardProduct from '../components/MainCardProduct';
import LoadingBox from '../components/LoadingBox';
import MessageBox from '../components/MessageBox';

import data from '../data';

export default function HomeScreen() {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);

    useEffect(() => {
      const fetchData = async () => {
        try 
        {
          setLoading(true);
          // const { data } = await axios.get('/api/products');
          setProducts(data.products);
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
                <MainCardProduct key={product.id} product={product} showLink={true}/>
              ))
            }         
          </div>
        )}
        
      </div>
        
  )
}
