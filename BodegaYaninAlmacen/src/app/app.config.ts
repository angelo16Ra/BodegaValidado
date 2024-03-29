import { ApplicationConfig } from '@angular/core';
import { provideRouter, withHashLocation } from '@angular/router';

import { HttpClient, HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http'
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser'
import { authInterceptor } from '../service/auth.interceptor';


export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes,withHashLocation()), provideHttpClient(),HttpClient, provideClientHydration(),{provide:
    HTTP_INTERCEPTORS, useClass: authInterceptor, multi: true
  }],
};