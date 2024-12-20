import React, { Suspense } from 'react'
import ReactDOM from 'react-dom/client'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { RouterProvider } from 'react-router-dom'
import { Router, I18nProvider } from '@ShareCores'
import { Loading } from '@ShareUis'
import { reduxStore } from '@ShareStores';
import { Provider } from 'react-redux';

const queryClient = new QueryClient();

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Provider store={reduxStore}>
      <QueryClientProvider client={queryClient}>
        <I18nProvider>
          <Suspense fallback={<Loading isShow={true} />}>
            <RouterProvider router={Router} />
          </Suspense>
        </I18nProvider>
      </QueryClientProvider>
    </Provider>
  </React.StrictMode>,
)
