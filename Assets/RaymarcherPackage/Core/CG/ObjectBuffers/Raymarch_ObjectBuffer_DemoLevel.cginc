//-----Registered Object Parameters
float4x4 _obj0Model;
float4x4 _obj1Model;
float4x4 _obj2Model;
float4x4 _obj3Model;
float4x4 _obj4Model;
float4x4 _obj5Model;
float4x4 _obj6Model;
float4x4 _obj7Model;
float4x4 _obj8Model;
float4x4 _obj9Model;
float4x4 _obj10Model;
float4x4 _obj11Model;
float4x4 _obj12Model;
float4x4 _obj13Model;
float4x4 _obj14Model;
float4x4 _obj15Model;
float4x4 _obj16Model;
float4x4 _obj17Model;
float4x4 _obj18Model;
float4x4 _obj19Model;
float4x4 _obj20Model;
float4x4 _obj21Model;
float4x4 _obj22Model;
float4x4 _obj23Model;
float4x4 _obj24Model;
float4x4 _obj25Model;
float4x4 _obj26Model;
float4x4 _obj27Model;
float4x4 _obj28Model;
float4x4 _obj29Model;

float obj0sm,enabled0;
float4 size0;
float obj1sm,enabled1;
float4 size1;
float obj2sm,enabled2;
float4 size2;
float obj3sm,enabled3;
float4 size3;
float obj4sm,enabled4;
float4 size4;
float obj5sm,enabled5;
float4 size5;
float obj6sm,enabled6;
float4 size6;
float obj7sm,enabled7;
float4 size7;
float obj8sm,enabled8;
float4 size8;
float obj9sm,enabled9;
float4 size9;
float obj10sm,enabled10;
float4 size10;
float obj11sm,enabled11;
float4 size11;
float obj12sm,enabled12;
float4 size12;
float obj13sm,enabled13;
float4 size13;
float obj14sm,enabled14;
float4 size14;
float obj15sm,enabled15;
float4 size15;
float obj16sm,enabled16;
float4 size16;
float obj17sm,enabled17;
float4 size17;
float obj18sm,enabled18;
float4 size18;
float obj19sm,enabled19;
float4 size19;
float obj20sm,enabled20;
float4 size20;
float obj21sm,enabled21;
float4 size21;
float obj22sm,enabled22;
float4 size22;
float obj23sm,enabled23;
float4 size23;
float obj24sm,enabled24;
float4 size24;
float obj25sm,enabled25;
float4 size25;
float obj26sm,enabled26;
float4 size26;
float obj27sm,enabled27;
float4 size27;
float obj28sm,enabled28;
float4 size28;
float obj29sm,enabled29;
float4 size29;

float3 color0;
float3 color1;
float3 color2;
float3 color3;
float3 color4;
float3 color5;
float3 color6;
float3 color7;
float3 color8;
float3 color9;
float3 color10;
float3 color11;
float3 color12;
float3 color13;
float3 color14;
float3 color15;
float3 color16;
float3 color17;
float3 color18;
float3 color19;
float3 color20;
float3 color21;
float3 color22;
float3 color23;
float3 color24;
float3 color25;
float3 color26;
float3 color27;
float3 color28;
float3 color29;

float4 fragSize0;
float3 DirfragSize0;
float fragEnabled0;
float4 fragSize1;
float3 DirfragSize1;
float fragEnabled1;
float4 fragSize2;
float3 DirfragSize2;
float fragEnabled2;
float4 fragSize3;
float3 DirfragSize3;
float fragEnabled3;
float4 fragSize4;
float3 DirfragSize4;
float fragEnabled4;
float4 fragSize5;
float3 DirfragSize5;
float fragEnabled5;
float4 fragSize6;
float3 DirfragSize6;
float fragEnabled6;
float4 fragSize7;
float3 DirfragSize7;
float fragEnabled7;
float4 fragSize8;
float3 DirfragSize8;
float fragEnabled8;
float4 fragSize9;
float3 DirfragSize9;
float fragEnabled9;
float4 fragSize10;
float3 DirfragSize10;
float fragEnabled10;
float4 fragSize11;
float3 DirfragSize11;
float fragEnabled11;
float4 fragSize12;
float3 DirfragSize12;
float fragEnabled12;
float4 fragSize13;
float3 DirfragSize13;
float fragEnabled13;
float4 fragSize14;
float3 DirfragSize14;
float fragEnabled14;
float4 fragSize15;
float3 DirfragSize15;
float fragEnabled15;
float4 fragSize16;
float3 DirfragSize16;
float fragEnabled16;
float4 fragSize17;
float3 DirfragSize17;
float fragEnabled17;
float4 fragSize18;
float3 DirfragSize18;
float fragEnabled18;
float4 fragSize19;
float3 DirfragSize19;
float fragEnabled19;
float4 fragSize20;
float3 DirfragSize20;
float fragEnabled20;
float4 fragSize21;
float3 DirfragSize21;
float fragEnabled21;
float4 fragSize22;
float3 DirfragSize22;
float fragEnabled22;
float4 fragSize23;
float3 DirfragSize23;
float fragEnabled23;
float4 fragSize24;
float3 DirfragSize24;
float fragEnabled24;
float4 fragSize25;
float3 DirfragSize25;
float fragEnabled25;
float4 fragSize26;
float3 DirfragSize26;
float fragEnabled26;
float4 fragSize27;
float3 DirfragSize27;
float fragEnabled27;
float4 fragSize28;
float3 DirfragSize28;
float fragEnabled28;
float4 fragSize29;
float3 DirfragSize29;
float fragEnabled29;

//-----Registered Shape Branches
float4 MAS_ShapeGenerator(float3 center)
{
   float4 result;

   float4 obj0 = GENERATOR_SHAPE(center,color0,size0 * enabled0,_obj0Model);
   obj0 = OP_Fragment(obj0,fragSize0,DirfragSize0,center,fragEnabled0);

   float4 obj1 = GENERATOR_SHAPE(center,color1,size1 * enabled1,_obj1Model);
   obj1 = OP_Fragment(obj1,fragSize1,DirfragSize1,center,fragEnabled1);

   float4 obj2 = GENERATOR_SHAPE(center,color2,size2 * enabled2,_obj2Model);
   obj2 = OP_Fragment(obj2,fragSize2,DirfragSize2,center,fragEnabled2);

   float4 obj3 = GENERATOR_SHAPE(center,color3,size3 * enabled3,_obj3Model);
   obj3 = OP_Fragment(obj3,fragSize3,DirfragSize3,center,fragEnabled3);

   float4 obj4 = GENERATOR_SHAPE(center,color4,size4 * enabled4,_obj4Model);
   obj4 = OP_Fragment(obj4,fragSize4,DirfragSize4,center,fragEnabled4);

   float4 obj5 = GENERATOR_SHAPE(center,color5,size5 * enabled5,_obj5Model);
   obj5 = OP_Fragment(obj5,fragSize5,DirfragSize5,center,fragEnabled5);

   float4 obj6 = GENERATOR_SHAPE(center,color6,size6 * enabled6,_obj6Model);
   obj6 = OP_Fragment(obj6,fragSize6,DirfragSize6,center,fragEnabled6);

   float4 obj7 = GENERATOR_SHAPE(center,color7,size7 * enabled7,_obj7Model);
   obj7 = OP_Fragment(obj7,fragSize7,DirfragSize7,center,fragEnabled7);

   float4 obj8 = GENERATOR_SHAPE(center,color8,size8 * enabled8,_obj8Model);
   obj8 = OP_Fragment(obj8,fragSize8,DirfragSize8,center,fragEnabled8);

   float4 obj9 = GENERATOR_SHAPE(center,color9,size9 * enabled9,_obj9Model);
   obj9 = OP_Fragment(obj9,fragSize9,DirfragSize9,center,fragEnabled9);

   float4 obj10 = GENERATOR_SHAPE(center,color10,size10 * enabled10,_obj10Model);
   obj10 = OP_Fragment(obj10,fragSize10,DirfragSize10,center,fragEnabled10);

   float4 obj11 = GENERATOR_SHAPE(center,color11,size11 * enabled11,_obj11Model);
   obj11 = OP_Fragment(obj11,fragSize11,DirfragSize11,center,fragEnabled11);

   float4 obj12 = GENERATOR_SHAPE(center,color12,size12 * enabled12,_obj12Model);
   obj12 = OP_Fragment(obj12,fragSize12,DirfragSize12,center,fragEnabled12);

   float4 obj13 = GENERATOR_SHAPE(center,color13,size13 * enabled13,_obj13Model);
   obj13 = OP_Fragment(obj13,fragSize13,DirfragSize13,center,fragEnabled13);

   float4 obj14 = GENERATOR_SHAPE(center,color14,size14 * enabled14,_obj14Model);
   obj14 = OP_Fragment(obj14,fragSize14,DirfragSize14,center,fragEnabled14);

   float4 obj15 = GENERATOR_SHAPE(center,color15,size15 * enabled15,_obj15Model);
   obj15 = OP_Fragment(obj15,fragSize15,DirfragSize15,center,fragEnabled15);

   float4 obj16 = GENERATOR_SHAPE(center,color16,size16 * enabled16,_obj16Model);
   obj16 = OP_Fragment(obj16,fragSize16,DirfragSize16,center,fragEnabled16);

   float4 obj17 = GENERATOR_SHAPE(center,color17,size17 * enabled17,_obj17Model);
   obj17 = OP_Fragment(obj17,fragSize17,DirfragSize17,center,fragEnabled17);

   float4 obj18 = GENERATOR_SHAPE(center,color18,size18 * enabled18,_obj18Model);
   obj18 = OP_Fragment(obj18,fragSize18,DirfragSize18,center,fragEnabled18);

   float4 obj19 = GENERATOR_SHAPE(center,color19,size19 * enabled19,_obj19Model);
   obj19 = OP_Fragment(obj19,fragSize19,DirfragSize19,center,fragEnabled19);

   float4 obj20 = GENERATOR_SHAPE(center,color20,size20 * enabled20,_obj20Model);
   obj20 = OP_Fragment(obj20,fragSize20,DirfragSize20,center,fragEnabled20);

   float4 obj21 = GENERATOR_SHAPE(center,color21,size21 * enabled21,_obj21Model);
   obj21 = OP_Fragment(obj21,fragSize21,DirfragSize21,center,fragEnabled21);

   float4 obj22 = GENERATOR_SHAPE(center,color22,size22 * enabled22,_obj22Model);
   obj22 = OP_Fragment(obj22,fragSize22,DirfragSize22,center,fragEnabled22);

   float4 obj23 = GENERATOR_SHAPE(center,color23,size23 * enabled23,_obj23Model);
   obj23 = OP_Fragment(obj23,fragSize23,DirfragSize23,center,fragEnabled23);

   float4 obj24 = GENERATOR_SHAPE(center,color24,size24 * enabled24,_obj24Model);
   obj24 = OP_Fragment(obj24,fragSize24,DirfragSize24,center,fragEnabled24);

   float4 obj25 = GENERATOR_SHAPE(center,color25,size25 * enabled25,_obj25Model);
   obj25 = OP_Fragment(obj25,fragSize25,DirfragSize25,center,fragEnabled25);

   float4 obj26 = GENERATOR_SHAPE(center,color26,size26 * enabled26,_obj26Model);
   obj26 = OP_Fragment(obj26,fragSize26,DirfragSize26,center,fragEnabled26);

   float4 obj27 = GENERATOR_SHAPE(center,color27,size27 * enabled27,_obj27Model);
   obj27 = OP_Fragment(obj27,fragSize27,DirfragSize27,center,fragEnabled27);

   float4 obj28 = GENERATOR_SHAPE(center,color28,size28 * enabled28,_obj28Model);
   obj28 = OP_Fragment(obj28,fragSize28,DirfragSize28,center,fragEnabled28);

   float4 obj29 = GENERATOR_SHAPE(center,color29,size29 * enabled29,_obj29Model);
   obj29 = OP_Fragment(obj29,fragSize29,DirfragSize29,center,fragEnabled29);

//-----Registered Advanced Operators
//Groups of obj0
   float4 group0 = OP_SmoothSubtraction(obj1,obj0,obj1sm);

//-----Connected Advanced Operators - Straight Unions

//-----Connected Advanced Operators - Smooth Unions


//-----Registered Final Groups & Single Objects
   float4 group1 = OP_SmoothUnion(group0,obj2,_MASrenderSmoothness);
   float4 group2 = OP_SmoothUnion(group1,obj3,_MASrenderSmoothness);
   float4 group3 = OP_SmoothUnion(group2,obj4,_MASrenderSmoothness);
   float4 group4 = OP_SmoothUnion(group3,obj5,_MASrenderSmoothness);
   float4 group5 = OP_SmoothUnion(group4,obj6,_MASrenderSmoothness);
   float4 group6 = OP_SmoothUnion(group5,obj7,_MASrenderSmoothness);
   float4 group7 = OP_SmoothUnion(group6,obj8,_MASrenderSmoothness);
   float4 group8 = OP_SmoothUnion(group7,obj9,_MASrenderSmoothness);
   float4 group9 = OP_SmoothUnion(group8,obj10,_MASrenderSmoothness);
   float4 group10 = OP_SmoothUnion(group9,obj11,_MASrenderSmoothness);
   float4 group11 = OP_SmoothUnion(group10,obj12,_MASrenderSmoothness);
   float4 group12 = OP_SmoothUnion(group11,obj13,_MASrenderSmoothness);
   float4 group13 = OP_SmoothUnion(group12,obj14,_MASrenderSmoothness);
   float4 group14 = OP_SmoothUnion(group13,obj15,_MASrenderSmoothness);
   float4 group15 = OP_SmoothUnion(group14,obj16,_MASrenderSmoothness);
   float4 group16 = OP_SmoothUnion(group15,obj17,_MASrenderSmoothness);
   float4 group17 = OP_SmoothUnion(group16,obj18,_MASrenderSmoothness);
   float4 group18 = OP_SmoothUnion(group17,obj19,_MASrenderSmoothness);
   float4 group19 = OP_SmoothUnion(group18,obj20,_MASrenderSmoothness);
   float4 group20 = OP_SmoothUnion(group19,obj21,_MASrenderSmoothness);
   float4 group21 = OP_SmoothUnion(group20,obj22,_MASrenderSmoothness);
   float4 group22 = OP_SmoothUnion(group21,obj23,_MASrenderSmoothness);
   float4 group23 = OP_SmoothUnion(group22,obj24,_MASrenderSmoothness);
   float4 group24 = OP_SmoothUnion(group23,obj25,_MASrenderSmoothness);
   float4 group25 = OP_SmoothUnion(group24,obj26,_MASrenderSmoothness);
   float4 group26 = OP_SmoothUnion(group25,obj27,_MASrenderSmoothness);
   float4 group27 = OP_SmoothUnion(group26,obj28,_MASrenderSmoothness);
   float4 group28 = OP_SmoothUnion(group27,obj29,_MASrenderSmoothness);
   result = group28;
   return result;
}