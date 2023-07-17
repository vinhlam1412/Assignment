import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfigurationComponent } from './components/configuration.component';
import { loadCSAttributeModuleAsChild } from './csattributes/csattribute/csattribute.module';
import { loadCSAttributeDetailModuleAsChild } from './csattribute-details/csattribute-detail/csattribute-detail.module';
import { loadHQTaskModuleAsChild } from './hqtasks/hqtask/hqtask.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: ConfigurationComponent,
  },
  { path: 'csattributes', loadChildren: loadCSAttributeModuleAsChild },
  { path: 'csattribute-details', loadChildren: loadCSAttributeDetailModuleAsChild },
  { path: 'hqtasks', loadChildren: loadHQTaskModuleAsChild },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ConfigurationRoutingModule {}
