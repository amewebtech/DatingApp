import { Injectable } from "@angular/core";
import { MemberEditComponent } from "../members/member-edit/member-edit.component";
import { CanDeactivate } from "@angular/router";

@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<MemberEditComponent>{
    canDeactivate( component: MemberEditComponent){
        if (component.editForm.dirty) {
            return confirm('Are your sure, you will loose your changes');
        }
        return true;
    }

}
