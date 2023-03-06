import { FormGroup, FormControl } from '@angular/forms';

export default class ValidateForm{
    static validateAllFormFiles(formGroup:FormGroup){
        Object.keys(formGroup.controls).forEach(element => {
         const control=formGroup.get(element);
         if(control instanceof FormControl){
           control.markAsDirty({onlySelf:true});
         }else if(control instanceof FormGroup){
           this.validateAllFormFiles(control)
         }

        });
 }
}